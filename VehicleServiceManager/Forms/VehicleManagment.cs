using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;
using VehicleServiceManager.Data;
using VehicleServiceManager.Models;

namespace VehicleServiceManager.Forms
{
    public partial class VehicleManagment : Form
    {
        private VehicleServiceContext _context;
        private BindingSource _vehicleBindingSource = new BindingSource();

        public VehicleManagment()
        {
            InitializeComponent();

            // wire events (since the designer currently doesn't show click hookups)
            Load += VehicleManagment_Load;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += btnClear_Click;
            btnSearch.Click += btnSearch_Click;
        }

        private void VehicleManagment_Load(object sender, EventArgs e)
        {
            _context = new VehicleServiceContext();
            _context.Database.EnsureCreated();

            LoadCustomers();
            LoadVehicles();

            // selection -> fill inputs
            dataVehicles.SelectionChanged += DataVehicles_SelectionChanged;
        }

        private void LoadCustomers()
        {
            _context.Customers.Load();

            cmbCustomer.DataSource = _context.Customers.Local.ToBindingList();
            cmbCustomer.DisplayMember = "FullName";
            cmbCustomer.ValueMember = "CustomerID";
        }

        private void LoadVehicles()
        {
            _context.Vehicles
                .Include(v => v.Customer)
                .Load();

            _vehicleBindingSource.DataSource = _context.Vehicles.Local.ToBindingList();
            dataVehicles.DataSource = _vehicleBindingSource;
            dataVehicles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void DataVehicles_SelectionChanged(object sender, EventArgs e)
        {
            if (dataVehicles.CurrentRow == null) return;

            if (dataVehicles.CurrentRow.DataBoundItem is not Vehicle vehicle) return;

            cmbCustomer.SelectedValue = vehicle.CustomerID;
            txtVIN.Text = vehicle.VIN;
            txtMake.Text = vehicle.Make;
            txtModel.Text = vehicle.Model;
            numYear.Value = vehicle.Year;
            txtLicensePlate.Text = vehicle.LicensePlate ?? "";
            numMileage.Value = vehicle.Mileage ?? 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateVehicleInputs()) return;

            var vehicle = new Vehicle
            {
                CustomerID = (int)cmbCustomer.SelectedValue,
                VIN = txtVIN.Text.Trim(),
                Make = txtMake.Text.Trim(),
                Model = txtModel.Text.Trim(),
                Year = (int)numYear.Value,
                LicensePlate = string.IsNullOrWhiteSpace(txtLicensePlate.Text) ? null : txtLicensePlate.Text.Trim(),
                Mileage = (int)numMileage.Value
            };

            string vin = txtVIN.Text.Trim();
            string plate = txtLicensePlate.Text.Trim();

            bool vinExists = _context.Vehicles.Any(v => v.VIN == vin);
            bool plateExists = !string.IsNullOrWhiteSpace(plate) && _context.Vehicles.Any(v => v.LicensePlate == plate);

            if (vinExists)
            {
                MessageBox.Show("VIN already exists. Please enter a unique VIN.");
                return;
            }
            if (plateExists)
            {
                MessageBox.Show("License plate already exists. Please enter a unique plate.");
                return;
            }


            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();

            LoadVehicles();
            ClearInputs();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataVehicles.CurrentRow == null)
            {
                MessageBox.Show("Select a vehicle to update.");
                return;
            }

            if (dataVehicles.CurrentRow.DataBoundItem is not Vehicle vehicle) return;
            if (!ValidateVehicleInputs()) return;

            vehicle.CustomerID = (int)cmbCustomer.SelectedValue;
            vehicle.VIN = txtVIN.Text.Trim();
            vehicle.Make = txtMake.Text.Trim();
            vehicle.Model = txtModel.Text.Trim();
            vehicle.Year = (int)numYear.Value;
            vehicle.LicensePlate = string.IsNullOrWhiteSpace(txtLicensePlate.Text) ? null : txtLicensePlate.Text.Trim();
            vehicle.Mileage = (int)numMileage.Value;

            _context.SaveChanges();

            LoadVehicles();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataVehicles.CurrentRow == null)
            {
                MessageBox.Show("Select a vehicle to delete.");
                return;
            }

            if (dataVehicles.CurrentRow.DataBoundItem is not Vehicle vehicle) return;

            var confirm = MessageBox.Show(
                $"Delete vehicle {vehicle.DisplayName}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            _context.Vehicles.Remove(vehicle);
            _context.SaveChanges();

            LoadVehicles();
            ClearInputs();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string term = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(term))
            {
                LoadVehicles();
                return;
            }

            var results = _context.Vehicles
                .Include(v => v.Customer)
                .Where(v =>
                    v.VIN.ToLower().Contains(term) ||
                    v.Make.ToLower().Contains(term) ||
                    v.Model.ToLower().Contains(term) ||
                    (v.LicensePlate != null && v.LicensePlate.ToLower().Contains(term)) ||
                    (v.Customer != null && (v.Customer.FirstName + " " + v.Customer.LastName).ToLower().Contains(term))
                )
                .OrderBy(v => v.Make)
                .ThenBy(v => v.Model)
                .ToList();

            dataVehicles.DataSource = results;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
            dataVehicles.ClearSelection();
        }

        private bool ValidateVehicleInputs()
        {
            if (cmbCustomer.SelectedValue == null)
            {
                MessageBox.Show("Select a customer (owner).");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtVIN.Text) || txtVIN.Text.Trim().Length != 17)
            {
                MessageBox.Show("VIN is required and must be 17 characters.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMake.Text))
            {
                MessageBox.Show("Make is required.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtModel.Text))
            {
                MessageBox.Show("Model is required.");
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            // Keep customer selection, or clear it if you prefer
            txtVIN.Clear();
            txtMake.Clear();
            txtModel.Clear();
            txtLicensePlate.Clear();
            numYear.Value = numYear.Minimum;
            numMileage.Value = 0;
            txtSearch.Clear();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            _context?.Dispose();
        }
    }
}
