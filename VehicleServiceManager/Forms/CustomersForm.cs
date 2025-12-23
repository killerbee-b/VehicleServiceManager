using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VehicleServiceManager.Data;
using VehicleServiceManager.Models;

namespace VehicleServiceManager.Forms
{
    public partial class CustomersForm : Form
    {
        private VehicleServiceContext _context;
        private BindingSource _customerBindingSource = new BindingSource();

        public CustomersForm()
        {
            InitializeComponent();

            // ADD INPUT VALIDATION EVENT HANDLERS
            txtFirstName.KeyPress += TxtFirstName_KeyPress;
            txtLastName.KeyPress += TxtLastName_KeyPress;
            txtPhone.KeyPress += TxtPhone_KeyPress;
            txtPhone.KeyDown += TxtPhone_KeyDown; // For spacebar dash
        }

        private void CustomersForm_Load(object sender, EventArgs e)
        {
            //Initialize EF Core context
            _context = new VehicleServiceContext();
            _context.Database.EnsureCreated();

            //Load customers into grid
            LoadCustomers();

            //When grid selection changes, populate text boxes
            dataGridViewCustomers.SelectionChanged += DataGridViewCustomers_SelectionChanged;
        }

        // INPUT VALIDATION: LETTERS ONLY (First Name)
        private void TxtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow letters, spaces, hyphens, backspace, and control keys
            if (!char.IsLetter(e.KeyChar) &&
                !char.IsControl(e.KeyChar) &&
                e.KeyChar != ' ' &&
                e.KeyChar != '-')
            {
                e.Handled = true; // Block the input
                SystemSounds.Beep.Play(); // Audio feedback
            }
        }

        // INPUT VALIDATION: LETTERS ONLY (Last Name)
        private void TxtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow letters, spaces, hyphens, backspace, and control keys
            if (!char.IsLetter(e.KeyChar) &&
                !char.IsControl(e.KeyChar) &&
                e.KeyChar != ' ' &&
                e.KeyChar != '-')
            {
                e.Handled = true; // Block the input
                SystemSounds.Beep.Play();
            }
        }

        //INPUT VALIDATION: NUMBERS ONLY (Phone)
        private void TxtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits, dash, backspace, and control keys
            if (!char.IsDigit(e.KeyChar) &&
                !char.IsControl(e.KeyChar) &&
                e.KeyChar != '-')
            {
                e.Handled = true; // Block the input
                SystemSounds.Beep.Play();
            }
        }

        // AUTO-DASH ON SPACEBAR (Phone)
        private void TxtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                e.SuppressKeyPress = true; // Prevent space from being entered

                // Add dash if there's text and last char isn't already a dash
                if (txtPhone.Text.Length > 0 && !txtPhone.Text.EndsWith("-"))
                {
                    txtPhone.AppendText("-");
                }
            }
        }

        private void LoadCustomers()
        {
            //Load all customers from database using EF Core
            _context.Customers.Load();

            //Bind to BindingSource
            _customerBindingSource.DataSource = _context.Customers.Local.ToBindingList();

            //Bind BindingSource to DataGridView
            dataGridViewCustomers.DataSource = _customerBindingSource;

            //Auto-size columns
            dataGridViewCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void DataGridViewCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.CurrentRow == null)
                return;

            var customer = dataGridViewCustomers.CurrentRow.DataBoundItem as Customer;
            if (customer == null)
                return;

            //Populate text boxes with selected customer data
            txtFirstName.Text = customer.FirstName;
            txtLastName.Text = customer.LastName;
            txtPhone.Text = customer.Phone;
            txtEmail.Text = customer.Email ?? "";
            txtAddress.Text = customer.Address ?? "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (!ValidateInputs())
                return;

            // Create new Customer entity
            var customer = new Customer
            {
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                Address = string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text.Trim(),
                CreatedDate = DateTime.Now
            };

            // Add to context and save to database (EF Core pattern)
            _context.Customers.Add(customer);
            _context.SaveChanges();

            MessageBox.Show("Customer added successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Refresh grid and clear inputs
            LoadCustomers();
            ClearInputs();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.CurrentRow == null)
            {
                MessageBox.Show("Please select a customer to update.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var customer = dataGridViewCustomers.CurrentRow.DataBoundItem as Customer;
            if (customer == null)
                return;

            // Pass customerID to ValidateInputs for update scenario
            if (!ValidateInputs(customer.CustomerID))
                return;

            //Update entity properties (EF Core tracks changes automatically)
            customer.FirstName = txtFirstName.Text.Trim();
            customer.LastName = txtLastName.Text.Trim();
            customer.Phone = txtPhone.Text.Trim();
            customer.Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
            customer.Address = string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text.Trim();

            // Save changes to database
            _context.SaveChanges();

            MessageBox.Show("Customer updated successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Refresh grid
            LoadCustomers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.CurrentRow == null)
            {
                MessageBox.Show("Please select a customer to delete.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var customer = dataGridViewCustomers.CurrentRow.DataBoundItem as Customer;
            if (customer == null)
                return;

            //Confirm deletion
            var results = MessageBox.Show
            (
                $"Are you sure you want to delete customer '{customer.FullName}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (results == DialogResult.Yes)
            {
                //Remove from context and save
                _context.Customers.Remove(customer);
                _context.SaveChanges();

                MessageBox.Show("Customer deleted successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Refresh grid and clear inputs
                LoadCustomers();
                ClearInputs();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                LoadCustomers(); //Show all if search is empty
                return;
            }

            //LINQ query to search
            var results = _context.Customers
                .Where(c => c.FirstName.ToLower().Contains(searchTerm) ||
                           c.LastName.ToLower().Contains(searchTerm) ||
                           c.Phone.Contains(searchTerm) ||
                           (c.Email != null && c.Email.ToLower().Contains(searchTerm)))
                .OrderBy(c => c.FirstName)
                .ThenBy(c => c.LastName)
                .ToList();

            dataGridViewCustomers.DataSource = results;

            if (results.Count == 0)
            {
                MessageBox.Show("No customers found matching your search.", "Search Results",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Reload context and data
            _context.Dispose();
            _context = new VehicleServiceContext();
            LoadCustomers();
            txtSearch.Clear();
            ClearInputs();

            MessageBox.Show("Data refreshed from database.", "Refreshed",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
            dataGridViewCustomers.ClearSelection();
        }

        // ENHANCED VALIDATION WITH DUPLICATE CHECKS
        private bool ValidateInputs(int? currentCustomerID = null)
        {
            //Clear previous errors
            errorProvider1.Clear();
            bool isValid = true;

            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string phone = txtPhone.Text.Trim();

            // 1. REQUIRED FIELDS
            if (string.IsNullOrWhiteSpace(firstName))
            {
                errorProvider1.SetError(txtFirstName, "First name is required.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                errorProvider1.SetError(txtLastName, "Last name is required.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(phone))
            {
                errorProvider1.SetError(txtPhone, "Phone number is required.");
                isValid = false;
            }

            // If basic validation failed, stop here
            if (!isValid)
            {
                MessageBox.Show("Please fix the errors before continuing.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 2. ✅ CHECK DUPLICATE NAME (FirstName + LastName)
            var duplicateName = _context.Customers
                .Where(c => c.FirstName.ToLower() == firstName.ToLower() &&
                           c.LastName.ToLower() == lastName.ToLower())
                .FirstOrDefault();

            // If updating, ignore the current customer
            if (duplicateName != null &&
                (currentCustomerID == null || duplicateName.CustomerID != currentCustomerID))
            {
                errorProvider1.SetError(txtFirstName, "Duplicate name!");
                errorProvider1.SetError(txtLastName, "This customer name already exists.");
                MessageBox.Show($"A customer named '{firstName} {lastName}' already exists!\n\n" +
                    "Please use a different name.",
                    "Duplicate Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 3. ✅ CHECK DUPLICATE PHONE NUMBER

            var duplicatePhone = _context.Customers
                .Where(c => c.Phone == phone)
                .FirstOrDefault();

            // If updating, ignore the current customer
            if (duplicatePhone != null &&
                (currentCustomerID == null || duplicatePhone.CustomerID != currentCustomerID))
            {
                errorProvider1.SetError(txtPhone, "This phone number is already registered.");
                MessageBox.Show($"Phone number '{phone}' is already used by:\n\n" +
                    $"{duplicatePhone.FullName}\n\n" +
                    "Please use a different phone number.",
                    "Duplicate Phone", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            errorProvider1.Clear();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            // Dispose context when form closes
            _context?.Dispose();
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            try
            {
                // Get all customers from database
                var customers = _context.Customers
                    .Select(c => new
                    {
                        c.CustomerID,
                        c.FirstName,
                        c.LastName,
                        FullName = c.FirstName + " " + c.LastName,
                        c.Phone,
                        c.Email,
                        c.Address
                    })
                    .ToList();

                Helpers.CsvExportHelper.ExportToCsv(customers, "Customers", "Customers");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error preparing customer data for export:\n{ex.Message}","Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
