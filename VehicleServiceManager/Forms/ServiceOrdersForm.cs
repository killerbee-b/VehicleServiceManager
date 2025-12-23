using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using VehicleServiceManager.Data;
using VehicleServiceManager.Models;

namespace VehicleServiceManager.Forms
{
    public partial class ServiceOrdersForm : Form
    {
        private VehicleServiceContext _context;
        private BindingSource _serviceOrderBindingSource = new BindingSource();
        public ServiceOrdersForm()
        {
            InitializeComponent();
        }

        private void ServiceOrdersForm_Load(object sender, EventArgs e)
        {
            //Initialize EF Core context
            _context = new VehicleServiceContext();
            _context.Database.EnsureCreated();

            // Load data
            LoadComboBoxes();
            LoadServiceOrders();

            //Event handlers
            dataGridViewOrders.SelectionChanged += DataGridViewOrders_SelectionChanged;
            numLaborHours.ValueChanged += CalculateTotalCost;
            numLaborRate.ValueChanged += CalculateTotalCost;
            chkMarkCompleted.CheckedChanged += chkMarkCompleted_CheckedChanged;
        }

        private void LoadComboBoxes()
        {
            // Load Customers
            var customers = _context.Customers.OrderBy(c => c.LastName).ToList();
            customers.Insert(0, new Customer { CustomerID = 0, FirstName = "All", LastName = "" });
            cmbCustomers.DataSource = customers;
            cmbCustomers.DisplayMember = "FullName";
            cmbCustomers.ValueMember = "CustomerID";
            cmbCustomers.SelectedIndex = 0;

            // Load Vehicles
            var vehicles = _context.Vehicles
                .Include(v => v.Customer)
                .OrderBy(v => v.Make)
                .ThenBy(v => v.Model)
                .Select(v => new
                {
                    v.VehicleID,
                    DisplayText = $"{v.Year} {v.Make} {v.Model} - {v.Customer.FullName}"
                })
                .ToList();
            vehicles.Insert(0, new { VehicleID = 0, DisplayText = "All Vehicles" });
            cmbVehicles.DataSource = vehicles;
            cmbVehicles.DisplayMember = "DisplayText";
            cmbVehicles.ValueMember = "VehicleID";
            cmbVehicles.SelectedIndex = 0;

            // Load Status filters (top ComboBox)
            var statusList = new List<string> { "All", "Pending", "In Progress", "Completed" };
            cmbStatusFilter.DataSource = new List<string>(statusList);
            cmbStatusFilter.SelectedIndex = 0;

            // Load Status for details ComboBox
            var statusDetailList = new List<string> { "Pending", "In Progress", "Completed" };
            cmbStatus.DataSource = statusDetailList;
            cmbStatus.SelectedIndex = 0;
        }

        private void LoadServiceOrders()
        {
            // Load all service orders with related data
            _context.ServiceOrders
                .Include(so => so.Vehicle)
                    .ThenInclude(v => v.Customer)
                .Load();

            _serviceOrderBindingSource.DataSource = _context.ServiceOrders.Local
                .OrderByDescending(so => so.ServiceDate)
                .Select(so => new
                {
                    so.ServiceOrderID,
                    ServiceDate = so.ServiceDate.ToString("dd-MMM-yyyy"),
                    Customer = so.Vehicle.Customer.FullName,
                    Vehicle = $"{so.Vehicle.Year} {so.Vehicle.Make} {so.Vehicle.Model}",
                    so.Description,
                    so.Status,
                    numLaborHours = so.LaborHours?.ToString("F2") ?? "0.00",
                    numLaborRate = so.LaborRate?.ToString("F2") ?? "0.00",
                    txtTotalCost = so.TotalCost?.ToString("F2") ?? "0.00",
                    so.Notes
                })
                .ToList();

            dataGridViewOrders.DataSource = _serviceOrderBindingSource;
            dataGridViewOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Hide ServiceOrderID column
            if (dataGridViewOrders.Columns["ServiceOrderID"] != null)
                dataGridViewOrders.Columns["ServiceOrderID"].Visible = false;
        }

        private void DataGridViewOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewOrders.CurrentRow == null)
                return;

            // Get ServiceOrderID from hidden column
            if (dataGridViewOrders.CurrentRow.Cells["ServiceOrderID"].Value == null)
                return;

            int serviceOrderID = Convert.ToInt32(dataGridViewOrders.CurrentRow.Cells["ServiceOrderID"].Value);

            var serviceOrder = _context.ServiceOrders
                .Include(so => so.Vehicle)
                .FirstOrDefault(so => so.ServiceOrderID == serviceOrderID);

            if (serviceOrder == null)
                return;

            //Populate from fields
            dtpServiceDate.Value = serviceOrder.ServiceDate;
            cmbStatus.SelectedItem = serviceOrder.Status;
            txtDescription.Text = serviceOrder.Description ?? "";
            numLaborHours.Value = serviceOrder.LaborHours ?? 0;
            numLaborRate.Value = serviceOrder.LaborRate ?? 25;
            txtTotalCost.Text = serviceOrder.TotalCost?.ToString("F2") ?? "0.00";
            dtpCompletedDate.Value = serviceOrder.CompletedDate ?? DateTime.Now;
            dtpCompletedDate.Enabled = (serviceOrder.Status == "Completed");
            chkMarkCompleted.Checked = (serviceOrder.Status == "Completed");
            txtNotes.Text = serviceOrder.Notes ?? "";

            // Set vehicle ComboBox - Just use SelectedValue directly
            cmbVehicles.SelectedValue = serviceOrder.VehicleID;

            btnViewInvoice.Enabled = (dataGridViewOrders.CurrentRow != null); // Enable View Invoice button when a row is selected
        }

        private void CalculateTotalCost(object sender, EventArgs e)
        {
            decimal laborHours = numLaborHours.Value;
            decimal laborRate = numLaborRate.Value;
            decimal totalCost = laborHours * laborRate;
            txtTotalCost.Text = totalCost.ToString("F2");
        }

        private void chkMarkCompleted_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMarkCompleted.Checked)
            {
                cmbStatus.SelectedItem = "Completed";
                dtpCompletedDate.Value = DateTime.Now;
                dtpCompletedDate.Enabled = true;
            }
            else
            {
                dtpCompletedDate.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            // Get selected vehicle
            int vehicleID = Convert.ToInt32(cmbVehicles.SelectedValue);
            if (vehicleID == 0)
            {
                MessageBox.Show("Please select a vehicle.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create new ServiceOrder
            var serviceOrder = new ServiceOrder
            {
                VehicleID = vehicleID,
                ServiceDate = dtpServiceDate.Value,
                Description = txtDescription.Text.Trim(),
                Status = cmbStatus.SelectedItem.ToString(),
                LaborHours = numLaborHours.Value,
                LaborRate = numLaborRate.Value,
                PartsCost = 0m,  // Initialize if not set
                CompletedDate = chkMarkCompleted.Checked ? dtpCompletedDate.Value : (DateTime?)null,
                Notes = string.IsNullOrWhiteSpace(txtNotes.Text) ? "" : txtNotes.Text.Trim(),  // Empty string, not null
                InvoiceNumber = GenerateInvoiceNumber(),
                PaymentStatus = "Unpaid",  
                AmountPaid = 0m,           
                TaxRate = 0.18m            
            };

            // Calculate totals before saving
            serviceOrder.CalculateTotals();
            serviceOrder.UpdatePaymentStatus();

            _context.ServiceOrders.Add(serviceOrder);
            _context.SaveChanges();


            MessageBox.Show("Service order added successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadServiceOrders();
            ClearInputs();
        }

        private string GenerateInvoiceNumber()
        {
            // Format: INV-YYYYMMDD-####
            string datePart = DateTime.Now.ToString("yyyyMMdd");

            // Get last invoice number for today
            var lastInvoice = _context.ServiceOrders
                .Where(so => so.InvoiceNumber != null && so.InvoiceNumber.StartsWith($"INV-{datePart}"))
                .OrderByDescending(so => so.ServiceOrderID)
                .FirstOrDefault();

            int nextNumber = 1;
            if(lastInvoice != null)
            {
                // Extract last 4 digits and increment
                string lastNumber = lastInvoice.InvoiceNumber.Substring(lastInvoice.InvoiceNumber.Length - 4);
                nextNumber = int.Parse(lastNumber) + 1;
            }

            return $"INV-{datePart}-{nextNumber:D4}";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrders.CurrentRow == null)
            {
                MessageBox.Show("Please select a service order to update.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateInputs())
                return;

            int serviceOrderID = Convert.ToInt32(dataGridViewOrders.CurrentRow.Cells["ServiceOrderID"].Value);
            var serviceOrder = _context.ServiceOrders.FirstOrDefault(so => so.ServiceOrderID == serviceOrderID);

            if (serviceOrder == null)
                return;

            // Get selected vehicle
            int vehicleID = Convert.ToInt32(cmbVehicles.SelectedValue);
            if (vehicleID == 0)
            {
                MessageBox.Show("Please select a vehicle.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Update properties
            serviceOrder.VehicleID = vehicleID;
            serviceOrder.ServiceDate = dtpServiceDate.Value;
            serviceOrder.Description = txtDescription.Text.Trim();
            serviceOrder.Status = cmbStatus.SelectedItem.ToString();
            serviceOrder.LaborHours = numLaborHours.Value;
            serviceOrder.LaborRate = numLaborRate.Value;
            serviceOrder.TotalCost = decimal.Parse(txtTotalCost.Text);
            serviceOrder.CompletedDate = chkMarkCompleted.Checked ? dtpCompletedDate.Value : (DateTime?)null;
            serviceOrder.Notes = string.IsNullOrWhiteSpace(txtNotes.Text) ? null : txtNotes.Text.Trim();

            _context.SaveChanges();

            MessageBox.Show("Service order updated successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadServiceOrders();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrders.CurrentRow == null)
            {
                MessageBox.Show("Please select a service order to delete.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int serviceOrderID = Convert.ToInt32(dataGridViewOrders.CurrentRow.Cells["ServiceOrderID"].Value);
            var serviceOrder = _context.ServiceOrders.FirstOrDefault(so => so.ServiceOrderID == serviceOrderID);

            if (serviceOrder == null)
                return;

            var result = MessageBox.Show(
                $"Are you sure you want to delete this service order?\n\nDescription: {serviceOrder.Description}",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                _context.ServiceOrders.Remove(serviceOrder);
                _context.SaveChanges();

                MessageBox.Show("Service order deleted successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadServiceOrders();
                ClearInputs();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
            dataGridViewOrders.ClearSelection();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Filter service orders based on selected criteria
            var query = _context.ServiceOrders
                .Include(so => so.Vehicle)
                    .ThenInclude(v => v.Customer)
                .AsQueryable();

            // Filter by Customer
            int customerID = Convert.ToInt32(cmbCustomers.SelectedValue);
            if (customerID != 0)
            {
                query = query.Where(so => so.Vehicle.CustomerID == customerID);
            }

            // Filter by Vehicle
            int vehicleID = Convert.ToInt32(cmbVehicles.SelectedValue);
            if (vehicleID != 0)
            {
                query = query.Where(so => so.VehicleID == vehicleID);
            }

            // Filter by Status
            string status = cmbStatusFilter.SelectedItem.ToString();
            if (status != "All")
            {
                query = query.Where(so => so.Status == status);
            }

            var results = query
                .OrderByDescending(so => so.ServiceDate)
                .Select(so => new
                {
                    so.ServiceOrderID,
                    ServiceDate = so.ServiceDate.ToString("dd-MMM-yyyy"),
                    Customer = so.Vehicle.Customer.FullName,
                    Vehicle = $"{so.Vehicle.Year} {so.Vehicle.Make} {so.Vehicle.Model}",
                    so.Description,
                    so.Status,
                    LaborHours = so.LaborHours.HasValue ? so.LaborHours.Value.ToString("F2") : "0.00",
                    LaborRate = so.LaborRate.HasValue ? so.LaborRate.Value.ToString("F2") : "0.00",
                    TotalCost = so.TotalCost.HasValue ? so.TotalCost.Value.ToString("F2") : "0.00",
                    so.Notes
                })
                .ToList();

            dataGridViewOrders.DataSource = results;

            if (results.Count == 0)
            {
                MessageBox.Show("No service orders found matching your criteria.", "Search Results",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            // Reset all filters
            cmbCustomers.SelectedIndex = 0;
            cmbVehicles.SelectedIndex = 0;
            cmbStatusFilter.SelectedIndex = 0;

            // Reload all data
            LoadServiceOrders();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Dispose and recreate context
            _context.Dispose();
            _context = new VehicleServiceContext();

            LoadComboBoxes();
            LoadServiceOrders();
            ClearInputs();

            MessageBox.Show("Data refreshed from database.", "Refreshed",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool ValidateInputs()
        {
            errorProvider1.Clear();
            bool isValid = true;

            // Validate Description
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                errorProvider1.SetError(txtDescription, "Description is required.");
                isValid = false;
            }

            // Validate Labor Hours
            if (numLaborHours.Value <= 0)
            {
                errorProvider1.SetError(numLaborHours, "Labor hours must be greater than 0.");
                isValid = false;
            }

            // Validate Labor Rate
            if (numLaborRate.Value <= 0)
            {
                errorProvider1.SetError(numLaborRate, "Labor rate must be greater than 0.");
                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show("Please fix the errors before continuing.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return isValid;
        }

        private void ClearInputs()
        {
            cmbVehicles.SelectedIndex = 0;
            dtpServiceDate.Value = DateTime.Now;
            cmbStatus.SelectedIndex = 0;
            txtDescription.Clear();
            numLaborHours.Value = 0;
            numLaborRate.Value = 25;
            txtTotalCost.Text = "0.00";
            dtpCompletedDate.Value = DateTime.Now;
            dtpCompletedDate.Enabled = false;
            chkMarkCompleted.Checked = false;
            txtNotes.Clear();
            errorProvider1.Clear();
            btnViewInvoice.Enabled = true;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            _context?.Dispose();
        }

        private void btnViewInvoice_Click(object sender, EventArgs e)
        {
            // Check if a service order is selected
            if (dataGridViewOrders.CurrentRow == null)
            {
                MessageBox.Show("Please select a service order to view the invoice.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Get ServiceOrderID from the selected row
            if (dataGridViewOrders.CurrentRow.Cells["ServiceOrderID"].Value == null)
            {
                MessageBox.Show("Invalid service order selected.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int serviceOrderID = Convert.ToInt32(dataGridViewOrders.CurrentRow.Cells["ServiceOrderID"].Value); // Why conver to INT32?

            // Open InvoiceForm with the selected service order
            try
            {
                InvoiceForm invoiceForm = new InvoiceForm(serviceOrderID);
                invoiceForm.ShowDialog(); // Show as modal dialog

                // Refresh the grid after invoice is closed (in case of any changes)
                LoadServiceOrders();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while opening the invoice: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            try
            {
                // Get data from database WITHOUT formatting
                var serviceOrdersRaw = _context.ServiceOrders
                    .Include(so => so.Vehicle)
                    .ThenInclude(v => v.Customer)
                    .ToList(); // Execute query NOW (get data into memory)

                // Format data in C# memory (AFTER database query)
                var serviceOrders = serviceOrdersRaw
                    .OrderByDescending(so => so.ServiceDate) // Now sorting in memory
                    .Select(so => new
                    {
                        so.ServiceOrderID,
                        InvoiceNumber = so.InvoiceNumber ?? "N/A",
                        ServiceDate = so.ServiceDate.ToString("dd-MMM-yyyy"), // Now works!
                        CustomerName = so.Vehicle.Customer.FirstName + " " + so.Vehicle.Customer.LastName,
                        CustomerPhone = so.Vehicle.Customer.Phone,
                        Vehicle = so.Vehicle.Year + " " + so.Vehicle.Make + " " + so.Vehicle.Model,
                        VIN = so.Vehicle.VIN,
                        LicensePlate = so.Vehicle.LicensePlate,
                        so.Description,
                        so.Status,
                        LaborHours = so.LaborHours ?? 0,
                        LaborRate = so.LaborRate ?? 0,
                        PartsCost = so.PartsCost ?? 0,
                        TotalCost = so.TotalCost ?? 0,
                        PaymentStatus = so.PaymentStatus ?? "Unpaid",
                        CompletedDate = so.CompletedDate.HasValue ? so.CompletedDate.Value.ToString("dd-MMM-yyyy") : "N/A",
                        so.Notes
                    })
                    .ToList();

                Helpers.CsvExportHelper.ExportToCsv(serviceOrders, "ServiceOrders", "Service Orders");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error preparing service order data for export:\n{ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
