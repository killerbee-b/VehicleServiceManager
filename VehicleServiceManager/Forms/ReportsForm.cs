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
    public partial class ReportsForm : Form
    {
        private VehicleServiceContext context;
        private List<dynamic> currentReportData;
        private string currentReportType;

        public ReportsForm()
        {
            InitializeComponent();

            // Set default date range to last 6 months
            dtpFromDate.Value = DateTime.Now.AddMonths(-6);
            dtpFromDate.Value = DateTime.Now;
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            try
            {
                context = new VehicleServiceContext();
                context.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMonthlyRevenue_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = dtpFromDate.Value.Date;
                DateTime toDate = dtpToDate.Value.Date.AddDays(1).AddSeconds(-1);

                // Use CompletedDate if available, otherwise ServiceDate
                var revenueData = context.ServiceOrders
                    .Where(so => (so.CompletedDate.HasValue && so.CompletedDate.Value >= fromDate && so.CompletedDate.Value <= toDate) ||
                                 (!so.CompletedDate.HasValue && so.ServiceDate >= fromDate && so.ServiceDate <= toDate))
                    .AsEnumerable()  // ✅ Switch to client evaluation to use complex logic
                    .GroupBy(so => new
                    {
                        Year = (so.CompletedDate ?? so.ServiceDate).Year,
                        Month = (so.CompletedDate ?? so.ServiceDate).Month
                    })
                    .Select(g => new
                    {
                        Year = g.Key.Year,
                        Month = g.Key.Month,
                        Monthname = new DateTime(g.Key.Year, g.Key.Month, 1).ToString("MMMM yyyy"),
                        TotalOrders = g.Count(),
                        TotalRevenue = g.Sum(so => so.TotalCost ?? 0),
                        PaidAmount = g.Sum(so => so.AmountPaid),
                        PendingAmount = g.Sum(so => (so.TotalCost ?? 0) - so.AmountPaid)
                    })
                    .OrderBy(x => x.Year).ThenBy(x => x.Month)
                    .ToList<dynamic>();

                if (revenueData.Count == 0)
                {
                    MessageBox.Show("No revenue data found for the selected date range.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Display in grid
                dataGridViewReport.DataSource = revenueData;
                currentReportData = revenueData;
                currentReportType = "Monthly Revenue Report";
                lblReportTitle.Text = $"💰 Monthly Revenue Report ({fromDate:dd-MMM-yyyy} to {toDate:dd-MMM-yyyy})";

                // Format columns
                FormatRevenueGrid();

                // Enable export buttons
                btnExportPdf.Enabled = true;
                btnExportCsv.Enabled = true;
                btnPrint.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating revenue report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatRevenueGrid()
        {
            {
                if (dataGridViewReport.Columns.Count == 0) return;

                // Hide raw year/month
                if (dataGridViewReport.Columns["Year"] != null)
                    dataGridViewReport.Columns["Year"].Visible = false;
                if (dataGridViewReport.Columns["Month"] != null)
                    dataGridViewReport.Columns["Month"].Visible = false;

                // Format headers and columns
                if (dataGridViewReport.Columns["MonthName"] != null)
                {
                    dataGridViewReport.Columns["MonthName"].HeaderText = "Month";
                    dataGridViewReport.Columns["MonthName"].Width = 150;
                }
                if (dataGridViewReport.Columns["TotalOrders"] != null)
                {
                    dataGridViewReport.Columns["TotalOrders"].HeaderText = "Total Orders";
                    dataGridViewReport.Columns["TotalOrders"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                if (dataGridViewReport.Columns["TotalRevenue"] != null)
                {
                    dataGridViewReport.Columns["TotalRevenue"].HeaderText = "Total Revenue";
                    dataGridViewReport.Columns["TotalRevenue"].DefaultCellStyle.Format = "C2";
                    dataGridViewReport.Columns["TotalRevenue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (dataGridViewReport.Columns["PaidAmount"] != null)
                {
                    dataGridViewReport.Columns["PaidAmount"].HeaderText = "Paid";
                    dataGridViewReport.Columns["PaidAmount"].DefaultCellStyle.Format = "C2";
                    dataGridViewReport.Columns["PaidAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridViewReport.Columns["PaidAmount"].DefaultCellStyle.ForeColor = Color.Green;
                }
                if (dataGridViewReport.Columns["PendingAmount"] != null)
                {
                    dataGridViewReport.Columns["PendingAmount"].HeaderText = "Pending";
                    dataGridViewReport.Columns["PendingAmount"].DefaultCellStyle.Format = "C2";
                    dataGridViewReport.Columns["PendingAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridViewReport.Columns["PendingAmount"].DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void btnCustomerHistory_Click(object sender, EventArgs e)
        {
            try
            {
                var customerHistory = context.Customers
                    .Include(c => c.Vehicles)
                        .ThenInclude(v => v.ServiceOrders)
                    .Select(c => new
                    {
                        CustomerID = c.CustomerID,
                        CustomerName = c.FirstName + " " + c.LastName,
                        c.Phone,
                        c.Email,
                        TotalVehicles = c.Vehicles.Count,
                        TotalServiceOrders = c.Vehicles.SelectMany(v => v.ServiceOrders).Count(),
                        TotalSpent = c.Vehicles
                            .SelectMany(v => v.ServiceOrders)
                            .Sum(so => so.TotalCost ?? 0),
                        LastService = c.Vehicles
                            .SelectMany(v => v.ServiceOrders)
                            .Max(so => (DateTime?)so.ServiceDate) ?? DateTime.MinValue,
                        OutstandingBalance = c.Vehicles
                            .SelectMany(v => v.ServiceOrders)
                            .Sum(so => (so.TotalCost ?? 0) - so.AmountPaid)
                    })
                    .Where(c => c.TotalServiceOrders > 0)
                    .OrderByDescending(c => c.TotalSpent)
                    .ToList<dynamic>();

                if (customerHistory.Count == 0)
                {
                    MessageBox.Show("No customer service history found.",
                        "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dataGridViewReport.DataSource = customerHistory;
                currentReportData = customerHistory;
                currentReportType = "Customer Service History";
                lblReportTitle.Text = "👥 Customer Service History Report";

                FormatCustomerHistoryGrid();

                btnExportPdf.Enabled = true;
                btnExportCsv.Enabled = true;
                btnPrint.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating customer history report: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatCustomerHistoryGrid()
        {
            if (dataGridViewReport.Columns.Count == 0) return;

            if (dataGridViewReport.Columns["CustomerID"] != null)
                dataGridViewReport.Columns["CustomerID"].Visible = false;

            if (dataGridViewReport.Columns["CustomerName"] != null)
            {
                dataGridViewReport.Columns["CustomerName"].HeaderText = "Customer";
                dataGridViewReport.Columns["CustomerName"].Width = 180;
            }
            if (dataGridViewReport.Columns["TotalVehicles"] != null)
            {
                dataGridViewReport.Columns["TotalVehicles"].HeaderText = "Vehicles";
                dataGridViewReport.Columns["TotalVehicles"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dataGridViewReport.Columns["TotalServiceOrders"] != null)
            {
                dataGridViewReport.Columns["TotalServiceOrders"].HeaderText = "Total Services";
                dataGridViewReport.Columns["TotalServiceOrders"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dataGridViewReport.Columns["TotalSpent"] != null)
            {
                dataGridViewReport.Columns["TotalSpent"].HeaderText = "Total Spent";
                dataGridViewReport.Columns["TotalSpent"].DefaultCellStyle.Format = "C2";
                dataGridViewReport.Columns["TotalSpent"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridViewReport.Columns["TotalSpent"].DefaultCellStyle.Font = new Font(dataGridViewReport.Font, FontStyle.Bold);
            }
            if (dataGridViewReport.Columns["LastService"] != null)
            {
                dataGridViewReport.Columns["LastService"].HeaderText = "Last Service";
                dataGridViewReport.Columns["LastService"].DefaultCellStyle.Format = "dd-MMM-yyyy";
            }
            if (dataGridViewReport.Columns["OutstandingBalance"] != null)
            {
                dataGridViewReport.Columns["OutstandingBalance"].HeaderText = "Outstanding";
                dataGridViewReport.Columns["OutstandingBalance"].DefaultCellStyle.Format = "C2";
                dataGridViewReport.Columns["OutstandingBalance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void btnLowStock_Click(object sender, EventArgs e)
        {
            try
            {
                var lowStockParts = context.Parts
                    .Where(p => p.StockQuantity <= p.MinStockLevel)
                    .Select(p => new
                    {
                        p.PartID,
                        p.PartNumber,
                        p.PartName,
                        p.Supplier,
                        p.UnitPrice,
                        CurrentStock = p.StockQuantity,
                        MinimumRequired = p.MinStockLevel,
                        StockDeficit = p.MinStockLevel - p.StockQuantity,
                        ReorderValue = (p.MinStockLevel - p.StockQuantity + 10) * p.UnitPrice,
                        Status = p.StockQuantity == 0 ? "OUT OF STOCK" :
                                 p.StockQuantity < p.MinStockLevel / 2 ? "CRITICAL" : "LOW"
                    })
                    .OrderBy(p => p.CurrentStock)
                    .ThenByDescending(p => p.ReorderValue)
                    .ToList<dynamic>();

                if (lowStockParts.Count == 0)
                {
                    MessageBox.Show("Great news! All parts are adequately stocked.",
                        "No Low Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Show all parts anyway
                    var allParts = context.Parts
                        .Select(p => new
                        {
                            p.PartID,
                            p.PartNumber,
                            p.PartName,
                            p.Supplier,
                            p.UnitPrice,
                            CurrentStock = p.StockQuantity,
                            MinimumRequired = p.MinStockLevel,
                            Status = "OK"
                        })
                        .OrderBy(p => p.PartName)
                        .ToList<dynamic>();

                    dataGridViewReport.DataSource = allParts;
                    currentReportData = allParts;
                }
                else
                {
                    dataGridViewReport.DataSource = lowStockParts;
                    currentReportData = lowStockParts;
                }

                currentReportType = "Low Stock Alert";
                lblReportTitle.Text = $"⚠️ Parts Low Stock Alert ({lowStockParts.Count} items need attention)";

                FormatLowStockGrid();

                btnExportPdf.Enabled = true;
                btnExportCsv.Enabled = true;
                btnPrint.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating low stock report: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatLowStockGrid()
        {
            if (dataGridViewReport.Columns.Count == 0) return;

            if (dataGridViewReport.Columns["PartID"] != null)
                dataGridViewReport.Columns["PartID"].Visible = false;

            if (dataGridViewReport.Columns["PartNumber"] != null)
            {
                dataGridViewReport.Columns["PartNumber"].HeaderText = "Part #";
                dataGridViewReport.Columns["PartNumber"].Width = 100;
            }
            if (dataGridViewReport.Columns["PartName"] != null)
            {
                dataGridViewReport.Columns["PartName"].HeaderText = "Part Name";
                dataGridViewReport.Columns["PartName"].Width = 200;
            }
            if (dataGridViewReport.Columns["Price"] != null)
            {
                dataGridViewReport.Columns["Price"].DefaultCellStyle.Format = "C2";
                dataGridViewReport.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dataGridViewReport.Columns["CurrentStock"] != null)
            {
                dataGridViewReport.Columns["CurrentStock"].HeaderText = "Current";
                dataGridViewReport.Columns["CurrentStock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dataGridViewReport.Columns["MinimumRequired"] != null)
            {
                dataGridViewReport.Columns["MinimumRequired"].HeaderText = "Minimum";
                dataGridViewReport.Columns["MinimumRequired"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dataGridViewReport.Columns["StockDeficit"] != null)
            {
                dataGridViewReport.Columns["StockDeficit"].HeaderText = "Deficit";
                dataGridViewReport.Columns["StockDeficit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewReport.Columns["StockDeficit"].DefaultCellStyle.ForeColor = Color.Red;
            }
            if (dataGridViewReport.Columns["ReorderValue"] != null)
            {
                dataGridViewReport.Columns["ReorderValue"].HeaderText = "Reorder Cost";
                dataGridViewReport.Columns["ReorderValue"].DefaultCellStyle.Format = "C2";
                dataGridViewReport.Columns["ReorderValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dataGridViewReport.Columns["Status"] != null)
            {
                dataGridViewReport.Columns["Status"].Width = 120;

                // Color-code status rows
                foreach (DataGridViewRow row in dataGridViewReport.Rows)
                {
                    if (row.Cells["Status"].Value != null)
                    {
                        string status = row.Cells["Status"].Value.ToString();
                        switch (status)
                        {
                            case "OUT OF STOCK":
                                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 238);
                                row.Cells["Status"].Style.ForeColor = Color.Red;
                                row.Cells["Status"].Style.Font = new Font(dataGridViewReport.Font, FontStyle.Bold);
                                break;
                            case "CRITICAL":
                                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 224);
                                row.Cells["Status"].Style.ForeColor = Color.DarkOrange;
                                row.Cells["Status"].Style.Font = new Font(dataGridViewReport.Font, FontStyle.Bold);
                                break;
                            case "LOW":
                                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 249, 196);
                                row.Cells["Status"].Style.ForeColor = Color.Goldenrod;
                                break;
                        }
                    }
                }
            }
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            if (currentReportData == null || currentReportData.Count == 0)
            {
                MessageBox.Show("No report data to export.", "Export Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Helpers.CsvExportHelper.ExportToCsv(currentReportData,
                currentReportType.Replace(" ", "_"), currentReportType);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            context?.Dispose();
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            if (currentReportData == null || currentReportData.Count == 0)
            {
                MessageBox.Show("No report data to export.", "Export Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Get visible columns and data from DataGridView
                var columnNames = new List<string>();
                var columnHeaders = new List<string>();

                foreach (DataGridViewColumn col in dataGridViewReport.Columns)
                {
                    if (col.Visible)
                    {
                        columnNames.Add(col.DataPropertyName);
                        columnHeaders.Add(col.HeaderText);
                    }
                }

                // Extract data from current report
                var tableData = new List<Dictionary<string, object>>();
                foreach (var item in currentReportData)
                {
                    var row = new Dictionary<string, object>();
                    var itemType = item.GetType();

                    foreach (var colName in columnNames)
                    {
                        var prop = itemType.GetProperty(colName);
                        if (prop != null)
                        {
                            row[colName] = prop.GetValue(item);
                        }
                    }
                    tableData.Add(row);
                }

                // Generate date range string
                string dateRange = $"{dtpFromDate.Value:dd-MMM-yyyy} to {dtpToDate.Value:dd-MMM-yyyy}";

                // Generate PDF
                Services.ReportPdfGenerator.GeneratePdf(tableData, columnNames, columnHeaders,
                                                        currentReportType, dateRange);

                MessageBox.Show("PDF report generated successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating PDF: {ex.Message}\n\n{ex.StackTrace}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (currentReportData == null || currentReportData.Count == 0)
            {
                MessageBox.Show("No report data to print.", "Print Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Get visible columns and data from DataGridView
                var columnNames = new List<string>();
                var columnHeaders = new List<string>();

                foreach (DataGridViewColumn col in dataGridViewReport.Columns)
                {
                    if (col.Visible)
                    {
                        columnNames.Add(col.DataPropertyName);
                        columnHeaders.Add(col.HeaderText);
                    }
                }

                // Extract data
                var tableData = new List<Dictionary<string, object>>();
                foreach (var item in currentReportData)
                {
                    var row = new Dictionary<string, object>();
                    var itemType = item.GetType();

                    foreach (var colName in columnNames)
                    {
                        var prop = itemType.GetProperty(colName);
                        if (prop != null)
                        {
                            row[colName] = prop.GetValue(item);
                        }
                    }
                    tableData.Add(row);
                }

                // Generate date range string
                string dateRange = $"{dtpFromDate.Value:dd-MMM-yyyy} to {dtpToDate.Value:dd-MMM-yyyy}";

                // Print
                var printDoc = new Services.ReportPrintDocument(tableData, columnNames, columnHeaders,
                                                                 currentReportType, dateRange);

                PrintPreviewDialog preview = new PrintPreviewDialog
                {
                    Document = printDoc,
                    Width = 1000,
                    Height = 700
                };
                preview.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
