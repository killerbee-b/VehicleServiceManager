using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using Microsoft.EntityFrameworkCore;
using VehicleServiceManager.Data;
using VehicleServiceManager.Models;

namespace VehicleServiceManager.Forms
{
    public partial class InvoiceForm : Form
    {
        private VehicleServiceContext _context;
        private int _serviceOrderId;
        private ServiceOrder _serviceOrder;

        // Constructor that accepts ServiceOrderID
        public InvoiceForm(int serviceOrderID)
        {
            InitializeComponent();
            _serviceOrderId = serviceOrderID;
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            try
            {
                //Initialize context
                _context = new VehicleServiceContext();

                //Load service order with related data
                _serviceOrder = _context.ServiceOrders
                    .Include(so => so.Vehicle)
                        .ThenInclude(v => v.Customer)
                    .FirstOrDefault(so => so.ServiceOrderID == _serviceOrderId);

                if (_serviceOrder == null)
                {
                    MessageBox.Show("Service Order not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                //Generate invoice number if it doesn't exist
                _serviceOrder.GenerateInvoiceNumber();

                //Calculate all invoice totals
                _serviceOrder.CalculateTotals();

                //Update payment status
                _serviceOrder.UpdatePaymentStatus();

                //Save changes to the database
                _context.SaveChanges();

                // Populate the form
                PopulateInvoiceData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading invoice:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void PopulateInvoiceData()
        {
            // HEADER SECTION
            lblInvoiceNumberHeader.Text = _serviceOrder.InvoiceNumber;
            lblDateHeader.Text = _serviceOrder.InvoiceDate?.ToString("dd MMMM yyyy");

            // INVOICE DETAILS
            lblServiceDate.Text = _serviceOrder.ServiceDate.ToString("dd-MMM-yyyy");

            // PAYMENT STATUS (Update styling based on status)
            lblPaymentStatus.Text = _serviceOrder.PaymentStatus.ToUpper();
            lblAmountDue.Text = $"Amount Due: €{_serviceOrder.AmountDue:F2}";

            // Set colors based on payment status
            switch (_serviceOrder.PaymentStatus)
            {
                case "Paid":
                    lblPaymentStatus.ForeColor = System.Drawing.Color.FromArgb(27, 94, 32); // Dark green
                    lblPaymentStatus.BackColor = System.Drawing.Color.FromArgb(200, 230, 201); // Light green
                    lblAmountDue.ForeColor = System.Drawing.Color.FromArgb(27, 94, 32);
                    break;

                case "Partial":
                    lblPaymentStatus.ForeColor = System.Drawing.Color.FromArgb(230, 81, 0); // Dark orange
                    lblPaymentStatus.BackColor = System.Drawing.Color.FromArgb(255, 224, 178); // Light orange
                    lblAmountDue.ForeColor = System.Drawing.Color.FromArgb(230, 81, 0);
                    break;

                case "Unpaid":
                default:
                    lblPaymentStatus.ForeColor = System.Drawing.Color.FromArgb(183, 28, 28); // Dark red
                    lblPaymentStatus.BackColor = System.Drawing.Color.FromArgb(255, 235, 238); // Light red
                    lblAmountDue.ForeColor = System.Drawing.Color.FromArgb(183, 28, 28);
                    break;
            }

            // CUSTOMER INFORMATION
            var customer = _serviceOrder.Vehicle.Customer;
            lblCustomerName.Text = customer.FullName;
            lblPhone.Text = customer.Phone;
            lblEmail.Text = customer.Email ?? "N/A";
            lblAddress.Text = customer.Address ?? "N/A";

            // VEHICLE INFORMATION
            var vehicle = _serviceOrder.Vehicle;
            lblVehicleName.Text = $"{vehicle.Year} {vehicle.Make} {vehicle.Model}";
            lblVIN.Text = $"VIN: {vehicle.VIN}";
            lblLicense.Text = $"License: {vehicle.LicensePlate}";

            // SERVICE DESCRIPTION
            txtDescription.Text = _serviceOrder.Description ?? "No description provided.";

            // COST BREAKDOWN
            decimal laborHours = _serviceOrder.LaborHours ?? 0;
            decimal laborRate = _serviceOrder.LaborRate ?? 0;
            decimal laborCost = laborHours * laborRate;

            lblLaborLabel.Text = "Labor";
            lblLaborDetails.Text = $"{laborHours:F1}h @ €{laborRate:F2}/h";
            lblLaborCost.Text = $"€{laborCost:F2}";

            lblPartsLabel.Text = "Parts";
            lblPartsCost.Text = $"€{_serviceOrder.PartsCost:F2}";

            // TOTALS
            lblSubtotal.Text = $"€{_serviceOrder.Subtotal:F2}";

            // Update tax label to show actual rate
            decimal taxRatePercent = _serviceOrder.TaxRate * 100;
            lblTaxLabel.Text = $"Tax ({taxRatePercent:F0}%)";
            lblTaxAmount.Text = $"€{_serviceOrder.TaxAmount:F2}";
            lblTotalAmount.Text = $"€{_serviceOrder.TotalCost:F2}";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGeneratePDF_Click(object sender, EventArgs e)
        {
            try
            {
                // Show progress message
                Cursor = Cursors.WaitCursor;

                // Generate PDF
                string filePath = Services.InvoicePdfGenerator.GeneratePdf(_serviceOrder);

                Cursor = Cursors.Default;

                // Show success message with options
                var result = MessageBox.Show(
                    $"✅ PDF Generated Successfully!\n\n" +
                    $"Invoice: {_serviceOrder.InvoiceNumber}\n" +
                    $"Customer: {_serviceOrder.Vehicle.Customer.FullName}\n" +
                    $"File: {Path.GetFileName(filePath)}\n\n" +
                    $"Location:\n{Path.GetDirectoryName(filePath)}\n\n" +
                    "Would you like to open the folder?",
                    "PDF Generated",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                // Open folder if user clicks Yes
                if (result == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("explorer.exe", Path.GetDirectoryName(filePath));
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show($"Error generating PDF:\n{ex.Message}\n\n{ex.StackTrace}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                // Create print dialog
                PrintDialog printDialog = new PrintDialog();

                // Create print document
                Services.InvoicePrintDocument printDoc = new Services.InvoicePrintDocument(_serviceOrder);

                printDialog.Document = printDoc;
                printDialog.AllowSomePages = false;
                printDialog.AllowSelection = false;
                printDialog.AllowCurrentPage = false;

                // Show print dialog
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Print
                        printDoc.Print();

                        MessageBox.Show(
                            $"✅ Invoice sent to printer!\n\n" +
                            $"Invoice: {_serviceOrder.InvoiceNumber}\n" +
                            $"Printer: {printDoc.PrinterSettings.PrinterName}",
                            "Print Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception printEx)
                    {
                        MessageBox.Show(
                            $"Error printing invoice:\n{printEx.Message}\n\n" +
                            "Please check your printer connection and try again.",
                            "Print Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing print:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            try
            {
                // Create print preview dialog
                PrintPreviewDialog previewDialog = new PrintPreviewDialog();

                // Create print document
                Services.InvoicePrintDocument printDoc = new Services.InvoicePrintDocument(_serviceOrder);

                previewDialog.Document = printDoc;
                previewDialog.Width = 900;
                previewDialog.Height = 700;
                previewDialog.StartPosition = FormStartPosition.CenterScreen;
                previewDialog.Text = $"Print Preview - {_serviceOrder.InvoiceNumber}";

                // Show preview
                previewDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error showing print preview:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            // Dispose context when form closes
            _context?.Dispose();
        }
    }
}
