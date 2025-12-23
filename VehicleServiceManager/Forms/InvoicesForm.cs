using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using VehicleServiceManager.Data;
using VehicleServiceManager.Models;
using Microsoft.VisualBasic;

namespace VehicleServiceManager.Forms
{
    public partial class InvoicesForm : Form
    {
        private VehicleServiceContext _context;
        public InvoicesForm()
        {
            InitializeComponent();
        }

        private void InvoicesForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Initialize context
                _context = new VehicleServiceContext();
                _context.Database.EnsureCreated();

                // Load status filter
                LoadStatusFilter();

                // Load all invoices
                LoadInvoices();

                // Wire up events
                dataGridViewInvoices.SelectionChanged += DataGridViewInvoices_SelectionChanged;
                dataGridViewInvoices.CellDoubleClick += DataGridViewInvoices_CellDoubleClick;
                txtSearch.KeyPress += TxtSearch_KeyPress;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Invoices:\n {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStatusFilter()
        {
            var statusList = new System.Collections.Generic.List<string>
            {
                "All",
                "Unpaid",
                "Partial",
                "Paid"
            };

            cmbStatusFilter.DataSource = statusList;
            cmbStatusFilter.SelectedIndex = 0;
            cmbStatusFilter.SelectedIndexChanged += CmbStatusFilter_SelectedIndexChanged;
        }

        private void LoadInvoices()
        {
            try
            {
                // Query only service orders that have invoice numbers
                var invoices = _context.ServiceOrders
                    .Include(so => so.Vehicle)
                        .ThenInclude(v => v.Customer)
                    .Where(so => so.InvoiceNumber != null && so.InvoiceNumber != "")
                    .OrderByDescending(so => so.InvoiceDate ?? so.ServiceDate)
                    .Select(so => new
                    {
                        so.ServiceOrderID,
                        InvoiceNumber = so.InvoiceNumber,
                        InvoiceDate = (so.InvoiceDate ?? so.ServiceDate).ToString("dd-MMM-yyyy"),
                        Customer = so.Vehicle.Customer.FullName,
                        Phone = so.Vehicle.Customer.Phone,
                        Vehicle = $"{so.Vehicle.Year} {so.Vehicle.Make} {so.Vehicle.Model}",
                        VIN = so.Vehicle.VIN,
                        LicensePlate = so.Vehicle.LicensePlate,
                        PaymentStatus = so.PaymentStatus ?? "Unpaid",
                        Total = so.TotalCost ?? 0,
                        AmountDue = so.AmountDue
                    })
                    .ToList();
                dataGridViewInvoices.DataSource = invoices;

                // Format columns
                FormatGrid();

                // Update count
                lblTotalInvoices.Text = $"Total Invoices: {invoices.Count}";

                // Disable button if no invoices
                bool hasInvoices = invoices.Count > 0;
                btnViewInvoice.Enabled = hasInvoices;
                btnPrintInvoice.Enabled = hasInvoices;
                btnUpdatePayment.Enabled = hasInvoices;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading invoices:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGrid()
        {
            if (dataGridViewInvoices.Columns.Count == 0)
                return;

            // Hide ServiceOrderID
            if (dataGridViewInvoices.Columns["ServiceOrderID"] != null)
                dataGridViewInvoices.Columns["ServiceOrderID"].Visible = false;

            // Set column headers
            if (dataGridViewInvoices.Columns["InvoiceNumber"] != null)
            {
                dataGridViewInvoices.Columns["InvoiceNumber"].HeaderText = "Invoice #";
                dataGridViewInvoices.Columns["InvoiceNumber"].Width = 120;
            }
            if (dataGridViewInvoices.Columns["InvoiceDate"] != null)
            {
                dataGridViewInvoices.Columns["InvoiceDate"].HeaderText = "Date";
                dataGridViewInvoices.Columns["InvoiceDate"].Width = 100;
            }
            if (dataGridViewInvoices.Columns["Customer"] != null)
            {
                dataGridViewInvoices.Columns["Customer"].HeaderText = "Customer";
                dataGridViewInvoices.Columns["Customer"].Width = 150;
            }
            if (dataGridViewInvoices.Columns["Phone"] != null)
            {
                dataGridViewInvoices.Columns["Phone"].HeaderText = "Phone";
                dataGridViewInvoices.Columns["Phone"].Width = 120;
            }
            if (dataGridViewInvoices.Columns["Vehicle"] != null)
            {
                dataGridViewInvoices.Columns["Vehicle"].HeaderText = "Vehicle";
                dataGridViewInvoices.Columns["Vehicle"].Width = 150;
            }
            if (dataGridViewInvoices.Columns["VIN"] != null)
            {
                dataGridViewInvoices.Columns["VIN"].HeaderText = "VIN";
                dataGridViewInvoices.Columns["VIN"].Width = 140;
            }
            if (dataGridViewInvoices.Columns["LicensePlate"] != null)
            {
                dataGridViewInvoices.Columns["LicensePlate"].HeaderText = "License Plate";
                dataGridViewInvoices.Columns["LicensePlate"].Width = 100;
            }
            if (dataGridViewInvoices.Columns["PaymentStatus"] != null)
            {
                dataGridViewInvoices.Columns["PaymentStatus"].HeaderText = "Payment Status";
                dataGridViewInvoices.Columns["PaymentStatus"].Width = 80;
            }
            if (dataGridViewInvoices.Columns["Total"] != null)
            {
                dataGridViewInvoices.Columns["Total"].HeaderText = "Total";
                dataGridViewInvoices.Columns["Total"].DefaultCellStyle.Format = "C2";
                dataGridViewInvoices.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridViewInvoices.Columns["Total"].Width = 90;
            }
            if (dataGridViewInvoices.Columns["AmountDue"] != null)
            {
                dataGridViewInvoices.Columns["AmountDue"].HeaderText = "Amount Due";
                dataGridViewInvoices.Columns["AmountDue"].DefaultCellStyle.Format = "C2";
                dataGridViewInvoices.Columns["AmountDue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridViewInvoices.Columns["AmountDue"].Width = 100;
            }

            // Color-code payment status rows
            foreach (DataGridViewRow row in dataGridViewInvoices.Rows)
            {
                if (row.Cells["PaymentStatus"].Value != null)
                {
                    string status = row.Cells["PaymentStatus"].Value.ToString();
                    switch (status)
                    {
                        case "Paid":
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(232, 245, 233); // Light green
                            break;
                        case "Partial":
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 243, 224); // Light orange
                            break;
                        case "Unpaid":
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 235, 238); // Light red
                            break;
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchInvoices();
        }

        private void TxtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Search on Enter key
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchInvoices();
                e.Handled = true;
            }
        }

        private void SearchInvoices()
        {
            string searchTerm = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                LoadInvoices();
                return;
            }

            try
            {
                // Multi-criteria search
                var results = _context.ServiceOrders
                    .Include(so => so.Vehicle)
                        .ThenInclude(v => v.Customer)
                    .Where(so => so.InvoiceNumber != null && so.InvoiceNumber != "")
                    .Where(so =>
                        so.InvoiceNumber.ToLower().Contains(searchTerm) || so.Vehicle.Customer.FirstName.ToLower().Contains(searchTerm)
                        || so.Vehicle.Customer.LastName.ToLower().Contains(searchTerm) ||
                        so.Vehicle.Customer.Phone.Contains(searchTerm) ||
                        so.Vehicle.VIN.ToLower().Contains(searchTerm) ||
                        so.Vehicle.LicensePlate.ToLower().Contains(searchTerm) ||
                        so.Vehicle.Make.ToLower().Contains(searchTerm) ||
                        so.Vehicle.Model.ToLower().Contains(searchTerm))
                    .OrderByDescending(so => so.InvoiceDate ?? so.ServiceDate)
                    .Select(so => new
                    {
                        so.ServiceOrderID,
                        InvoiceNumber = so.InvoiceNumber,
                        InvoiceDate = (so.InvoiceDate ?? so.ServiceDate).ToString("dd-MMM-yyyy"),
                        Customer = so.Vehicle.Customer.FullName,
                        Phone = so.Vehicle.Customer.Phone,
                        Vehicle = $"{so.Vehicle.Year} {so.Vehicle.Make} {so.Vehicle.Model}",
                        VIN = so.Vehicle.VIN,
                        LicensePlate = so.Vehicle.LicensePlate,
                        PaymentStatus = so.PaymentStatus ?? "Unpaid",
                        Total = so.TotalCost ?? 0,
                        AmountDue = so.AmountDue
                    })
                    .ToList();

                dataGridViewInvoices.DataSource = results;
                FormatGrid();
                lblTotalInvoices.Text = $"Found: {results.Count} invoice(s)";

                if (results.Count == 0)
                {
                    MessageBox.Show($"No invoices found matching '{txtSearch.Text}'", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching invoices:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbStatusFilter.SelectedIndex = 0;
            LoadInvoices();
        }

        private void CmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterByStatus();
        }

        private void FilterByStatus()
        {
            string selectedStatus = cmbStatusFilter.SelectedItem.ToString();

            if (selectedStatus == "All")
            {
                LoadInvoices();
                return;
            }

            try
            {
                var filtered = _context.ServiceOrders
                    .Include(so => so.Vehicle)
                        .ThenInclude(v => v.Customer)
                    .Where(so => so.InvoiceNumber != null && so.InvoiceNumber != "")
                    .Where(so => so.PaymentStatus == selectedStatus)
                    .OrderByDescending(so => so.InvoiceDate ?? so.ServiceDate)
                    .Select(so => new
                    {
                        so.ServiceOrderID,
                        InvoiceNumber = so.InvoiceNumber,
                        InvoiceDate = (so.InvoiceDate ?? so.ServiceDate).ToString("dd-MMM-yyyy"),
                        Customer = so.Vehicle.Customer.FullName,
                        Phone = so.Vehicle.Customer.Phone,
                        Vehicle = $"{so.Vehicle.Year} {so.Vehicle.Make} {so.Vehicle.Model}",
                        VIN = so.Vehicle.VIN,
                        LicensePlate = so.Vehicle.LicensePlate,
                        PaymentStatus = so.PaymentStatus ?? "Unpaid",
                        Total = so.TotalCost ?? 0,
                        AmountDue = so.AmountDue
                    })
                    .ToList();

                dataGridViewInvoices.DataSource = filtered;
                FormatGrid();
                lblTotalInvoices.Text = $"{selectedStatus}: {filtered.Count} invoice(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering invoices:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewInvoices_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = dataGridViewInvoices.CurrentRow != null;
            btnViewInvoice.Enabled = hasSelection;
            btnPrintInvoice.Enabled = hasSelection;
            btnUpdatePayment.Enabled = hasSelection;
        }

        private void DataGridViewInvoices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Open invoice on double-click
            if (e.RowIndex >= 0)
            {
                OpenSelectedInvoice();
            }
        }

        private void btnViewInvoice_Click(object sender, EventArgs e)
        {
            OpenSelectedInvoice();
        }

        private void OpenSelectedInvoice()
        {
            if (dataGridViewInvoices.CurrentRow == null)
            {
                MessageBox.Show("Please select an invoice to view.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int serviceOrderID = Convert.ToInt32(dataGridViewInvoices.CurrentRow.Cells["ServiceOrderID"].Value);

                InvoiceForm invoiceForm = new InvoiceForm(serviceOrderID);
                invoiceForm.ShowDialog();

                // Refresh grid after invoice closes (in case payment status changed)
                LoadInvoices();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening invoice:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            if (dataGridViewInvoices.CurrentRow == null)
            {
                MessageBox.Show("Please select an invoice to print.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int serviceOrderID = Convert.ToInt32(dataGridViewInvoices.CurrentRow.Cells["ServiceOrderID"].Value);

                // Load service order with related data
                var serviceOrder = _context.ServiceOrders
                    .Include(so => so.Vehicle)
                        .ThenInclude(v => v.Customer)
                    .FirstOrDefault(so => so.ServiceOrderID == serviceOrderID);

                if (serviceOrder == null)
                    return;

                // Create print dialog
                PrintDialog printDialog = new PrintDialog();
                Services.InvoicePrintDocument printDoc = new Services.InvoicePrintDocument(serviceOrder);

                printDialog.Document = printDoc;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();

                    MessageBox.Show($"✅ Invoice {serviceOrder.InvoiceNumber} sent to printer!",
                        "Print Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing invoice:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdatePayment_Click(object sender, EventArgs e)
        {
            if (dataGridViewInvoices.CurrentRow == null)
                return;

            try
            {
                int serviceOrderID = Convert.ToInt32(dataGridViewInvoices.CurrentRow.Cells["ServiceOrderID"].Value);
                var serviceOrder = _context.ServiceOrders.FirstOrDefault(so => so.ServiceOrderID == serviceOrderID);

                if (serviceOrder == null)
                    return;

                string currentStatus = serviceOrder.PaymentStatus ?? "Unpaid";
                decimal totalCost = serviceOrder.TotalCost ?? 0;
                decimal currentAmountPaid = serviceOrder.AmountPaid;
                decimal amountDue = serviceOrder.AmountDue;

                // ✅ STEP 1: Ask user to choose payment status
                string message = $"Current Invoice Details:\n\n" +
                    $"• Total: €{totalCost:F2}\n" +
                    $"• Current Status: {currentStatus}\n" +
                    $"• Amount Paid: €{currentAmountPaid:F2}\n" +
                    $"• Amount Due: €{amountDue:F2}\n\n" +
                    $"Choose new payment status:\n\n" +
                    $"[YES] = Mark as PAID (€{totalCost:F2})\n" +
                    $"[NO] = Mark as UNPAID (€0.00)\n" +
                    $"[CANCEL] = Enter PARTIAL payment amount";

                DialogResult result = MessageBox.Show(message, "Update Payment Status",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Mark as PAID
                    serviceOrder.AmountPaid = totalCost;
                    serviceOrder.UpdatePaymentStatus();
                    _context.SaveChanges();

                    MessageBox.Show($"✅ Invoice marked as PAID!\n\nAmount Paid: €{totalCost:F2}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadInvoices();
                }
                else if (result == DialogResult.No)
                {
                    // Mark as UNPAID
                    serviceOrder.AmountPaid = 0;
                    serviceOrder.UpdatePaymentStatus();
                    _context.SaveChanges();

                    MessageBox.Show($"Invoice marked as UNPAID.\n\nAmount Due: €{totalCost:F2}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadInvoices();
                }
                else if (result == DialogResult.Cancel)
                {
                    // Ask for partial amount
                    string partialPrompt = $"Enter partial payment amount:\n\n" +
                        $"Total Invoice: €{totalCost:F2}\n" +
                        $"Currently Paid: €{currentAmountPaid:F2}\n" +
                        $"Amount Due: €{amountDue:F2}\n\n" +
                        $"Enter amount to pay (without € symbol):";

                    string input = Microsoft.VisualBasic.Interaction.InputBox(partialPrompt,"Partial Payment", currentAmountPaid.ToString("F2"));

                    if (!string.IsNullOrWhiteSpace(input))
                    {
                        if (decimal.TryParse(input, out decimal partialAmount))
                        {
                            // Validate amount
                            if (partialAmount < 0)
                            {
                                MessageBox.Show("Amount cannot be negative!", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            if (partialAmount > totalCost)
                            {
                                MessageBox.Show($"Amount cannot exceed total invoice (€{totalCost:F2})!", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            // Update amount
                            serviceOrder.AmountPaid = partialAmount;
                            serviceOrder.UpdatePaymentStatus();
                            _context.SaveChanges();

                            string statusMsg = serviceOrder.PaymentStatus == "Paid" ? "✅ PAID IN FULL!" : serviceOrder.PaymentStatus == "Unpaid" ? "UNPAID" : "⚠️ PARTIAL PAYMENT";

                            MessageBox.Show($"{statusMsg}\n\n" +
                                $"Amount Paid: €{serviceOrder.AmountPaid:F2}\n" + $"Amount Due: €{serviceOrder.AmountDue:F2}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadInvoices();
                        }
                        else
                        {
                            MessageBox.Show("Invalid number format. Please enter a valid amount.",
                                "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating payment:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _context.Dispose();
            _context = new VehicleServiceContext();
            LoadInvoices();
            txtSearch.Clear();
            cmbStatusFilter.SelectedIndex = 0;
            MessageBox.Show("Data refreshed from database.", "Refreshed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            _context?.Dispose();
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            try
            {
                // Get all invoices
                var invoices = _context.ServiceOrders
                    .Include(so => so.Vehicle)
                        .ThenInclude(v => v.Customer)
                    .Where(so => so.InvoiceNumber != null && so.InvoiceNumber != "")
                    .Select(so => new
                    {
                        so.InvoiceNumber,
                        InvoiceDate = so.InvoiceDate.HasValue ?
                            so.InvoiceDate.Value.ToString("yyyy-MM-dd") :
                            so.ServiceDate.ToString("yyyy-MM-dd"),
                        CustomerName = so.Vehicle.Customer.FirstName + " " + so.Vehicle.Customer.LastName,
                        CustomerPhone = so.Vehicle.Customer.Phone,
                        CustomerEmail = so.Vehicle.Customer.Email ?? "N/A",
                        Vehicle = so.Vehicle.Year + " " + so.Vehicle.Make + " " + so.Vehicle.Model,
                        VIN = so.Vehicle.VIN,
                        LicensePlate = so.Vehicle.LicensePlate,
                        ServiceDescription = so.Description,
                        LaborCost = (so.LaborHours ?? 0) * (so.LaborRate ?? 0),
                        PartsCost = so.PartsCost ?? 0,
                        Subtotal = so.Subtotal ?? 0,
                        TaxAmount = so.TaxAmount ?? 0,
                        TotalCost = so.TotalCost ?? 0,
                        AmountPaid = so.AmountPaid,
                        AmountDue = so.AmountDue,
                        PaymentStatus = so.PaymentStatus ?? "Unpaid"
                    })
                    .OrderByDescending(i => i.InvoiceDate)
                    .ToList();

                Helpers.CsvExportHelper.ExportToCsv(invoices, "Invoices", "Invoices");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error preparing invoice data for export:\n{ex.Message}",
                    "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
