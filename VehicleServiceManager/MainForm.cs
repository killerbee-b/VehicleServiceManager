using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using VehicleServiceManager.Data;
using VehicleServiceManager.Forms;

namespace VehicleServiceManager
{
    public partial class MainForm : Form
    {
        private VehicleServiceContext _context;
        private Chart chartMonthlyRevenue;
        private Chart chartOrderStatus;
        private Chart chartCustomerGrowth;

        public MainForm()
        {
            InitializeComponent();
            InitializeCharts();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {

                //Initialize Entity Framework Core DbContext
                _context = new VehicleServiceContext();

                //Ensure database connection works
                _context.Database.EnsureCreated();

                //Load Dashboard Immediately
                LoadDashboardData();

                //Use LINQ to count customers (demonstrates EF Core + LINQ working)
                int customerCount = _context.Customers.Count();
                int vehicleCount = _context.Vehicles.Count();
                int serviceOrderCount = _context.ServiceOrders.Count();
                int partCount = _context.Parts.Count();

                MessageBox.Show(
                    $"✅ Database Connected Successfully!\n\n" +
                    $"Database Statistics:\n" +
                    $"Customers: {customerCount}\n" +
                    $"Vehicles: {vehicleCount}\n" +
                    $"Service Orders: {serviceOrderCount}\n" +
                    $"Parts: {partCount}",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                   $"❌ Database Connection Failed!\n\n" +
                   $"Error: {ex.Message}\n\n" +
                   $"Check your connection string in VehicleServiceContext.cs",
                   "Error",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
        }

        private void InitializeCharts()
        {
            // Chart 1: Monthly Revenue (Bar Chart)
            chartMonthlyRevenue = new Chart
            {
                Location = new Point(0, 0),
                Size = new Size(300, 280),
                BackColor = Color.White
            };

            ChartArea area1 = new ChartArea("RevenueArea");
            area1.AxisX.MajorGrid.Enabled = false;
            area1.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartMonthlyRevenue.ChartAreas.Add(area1);

            Series series1 = new Series("Revenue")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.SteelBlue,
                IsValueShownAsLabel = true
            };
            chartMonthlyRevenue.Series.Add(series1);

            Title title1 = new Title("📊 Monthly Revenue", Docking.Top,
                new Font("Segoe UI", 11, FontStyle.Bold), Color.DarkSlateGray);
            chartMonthlyRevenue.Titles.Add(title1);

            panelCharts.Controls.Add(chartMonthlyRevenue);

            // Chart 2: Service Order Status (Pie Chart)
            chartOrderStatus = new Chart
            {
                Location = new Point(315, 0),
                Size = new Size(300, 280),
                BackColor = Color.White
            };

            ChartArea area2 = new ChartArea("StatusArea");
            chartOrderStatus.ChartAreas.Add(area2);

            Series series2 = new Series("Status")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            chartOrderStatus.Series.Add(series2);

            // ADD LEGEND ONLY ONCE HERE - NOT in LoadOrderStatusChart()
            Legend legend2 = new Legend("StatusLegend");
            legend2.Docking = Docking.Bottom;
            chartOrderStatus.Legends.Add(legend2);

            Title title2 = new Title("🥧 Order Status", Docking.Top,
                new Font("Segoe UI", 11, FontStyle.Bold), Color.DarkSlateGray);
            chartOrderStatus.Titles.Add(title2);

            panelCharts.Controls.Add(chartOrderStatus);

            // Chart 3: Customer Growth (Line Chart)
            chartCustomerGrowth = new Chart
            {
                Location = new Point(630, 0),
                Size = new Size(290, 280),
                BackColor = Color.White
            };

            ChartArea area3 = new ChartArea("GrowthArea");
            area3.AxisX.MajorGrid.Enabled = false;
            area3.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartCustomerGrowth.ChartAreas.Add(area3);

            Series series3 = new Series("Customers")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.MediumSeaGreen,
                BorderWidth = 3,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8
            };
            chartCustomerGrowth.Series.Add(series3);

            Title title3 = new Title("📈 Customer Growth", Docking.Top,
                new Font("Segoe UI", 11, FontStyle.Bold), Color.DarkSlateGray);
            chartCustomerGrowth.Titles.Add(title3);

            panelCharts.Controls.Add(chartCustomerGrowth);
        }

        private void LoadDashboardData()
        {
            try
            {
                // Load KPI data
                int customerCount = _context.Customers.Count();
                int vehicleCount = _context.Vehicles.Count();
                int activeOrderCount = _context.ServiceOrders.Count(o => o.Status != "Completed");
                decimal totalRevenue = _context.ServiceOrders
                    .Where(o => o.Status == "Completed")
                    .Sum(o => o.TotalCost ?? 0);

                // Update KPI cards
                lblCustomersCount.Text = customerCount.ToString();
                lblVehiclesCount.Text = vehicleCount.ToString();
                lblOrdersCount.Text = activeOrderCount.ToString();
                lblRevenueAmount.Text = $"€{totalRevenue:N2}";

                // Load chart data
                LoadMonthlyRevenueChart();
                LoadOrderStatusChart();
                LoadCustomerGrowthChart();

                // Load recent activity
                LoadRecentActivity();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMonthlyRevenueChart()
        {
            chartMonthlyRevenue.Series["Revenue"].Points.Clear();

            var monthlyRevenue = _context.ServiceOrders
                .Where(o => o.ServiceDate.Year == DateTime.Now.Year)
                .GroupBy(o => o.ServiceDate.Month)
                .Select(g => new { Month = g.Key, Revenue = g.Sum(o => o.TotalCost ?? 0) })
                .OrderBy(x => x.Month)
                .ToList();

            foreach (var item in monthlyRevenue)
            {
                string monthName = new DateTime(2000, item.Month, 1).ToString("MMM");
                chartMonthlyRevenue.Series["Revenue"].Points.AddXY(monthName, item.Revenue);
            }

            if (monthlyRevenue.Count == 0)
            {
                chartMonthlyRevenue.Series["Revenue"].Points.AddXY("Jan", 0);
            }
        }

        private void LoadOrderStatusChart()
        {
            // FIXED: Only clear points, don't add legend again
            chartOrderStatus.Series["Status"].Points.Clear();

            int pending = _context.ServiceOrders.Count(o => o.Status == "Pending");
            int inProgress = _context.ServiceOrders.Count(o => o.Status == "In Progress");
            int completed = _context.ServiceOrders.Count(o => o.Status == "Completed");

            if (pending + inProgress + completed == 0)
            {
                // Show placeholder if no data
                var point = chartOrderStatus.Series["Status"].Points.Add(1);
                point.LegendText = "No Orders";
                point.Label = "No Data";
                point.Color = Color.LightGray;
            }
            else
            {
                if (pending > 0)
                {
                    var point1 = chartOrderStatus.Series["Status"].Points.Add(pending);
                    point1.LegendText = $"Pending ({pending})";
                    point1.Label = pending.ToString();
                    point1.Color = Color.Orange;
                }

                if (inProgress > 0)
                {
                    var point2 = chartOrderStatus.Series["Status"].Points.Add(inProgress);
                    point2.LegendText = $"In Progress ({inProgress})";
                    point2.Label = inProgress.ToString();
                    point2.Color = Color.DodgerBlue;
                }

                if (completed > 0)
                {
                    var point3 = chartOrderStatus.Series["Status"].Points.Add(completed);
                    point3.LegendText = $"Completed ({completed})";
                    point3.Label = completed.ToString();
                    point3.Color = Color.MediumSeaGreen;
                }
            }
        }

        private void LoadCustomerGrowthChart()
        {
            chartCustomerGrowth.Series["Customers"].Points.Clear();

            var customerGrowth = _context.Customers
                .Where(c => c.CreatedDate.Year == DateTime.Now.Year)
                .GroupBy(c => c.CreatedDate.Month)
                .Select(g => new { Month = g.Key, Count = g.Count() })
                .OrderBy(x => x.Month)
                .ToList();

            int cumulative = 0;
            for (int i = 1; i <= 12; i++)
            {
                var monthData = customerGrowth.FirstOrDefault(x => x.Month == i);
                cumulative += monthData?.Count ?? 0;

                string monthName = new DateTime(2000, i, 1).ToString("MMM");
                chartCustomerGrowth.Series["Customers"].Points.AddXY(monthName, cumulative);
            }
        }

        private void LoadRecentActivity()
        {
            listBoxRecentActivity.Items.Clear();

            var recentOrders = _context.ServiceOrders
                .Include(o => o.Vehicle)
                .ThenInclude(v => v.Customer)
                .OrderByDescending(o => o.ServiceDate)
                .Take(10)
                .ToList();

            foreach (var order in recentOrders)
            {
                string activity = $"🔧 {order.ServiceDate.ToString("MMM dd")} - {order.Vehicle?.Make} {order.Vehicle?.Model} - {order.Status}";
                listBoxRecentActivity.Items.Add(activity);
            }

            if (recentOrders.Count == 0)
            {
                listBoxRecentActivity.Items.Add("• No recent activity");
            }
        }

        // Existing sidebar button handlers
        private void btnCustomers_Click(object sender, EventArgs e)
        {
            CustomersForm customersForm = new CustomersForm();
            customersForm.ShowDialog();
            LoadDashboardData(); // Refresh after closing
        }

        private void btnServiceOrders_Click(object sender, EventArgs e)
        {
            ServiceOrdersForm ordersForm = new ServiceOrdersForm();
            ordersForm.ShowDialog();
            LoadDashboardData(); // Refresh after closing
        }

        private void btnInvoices_Click(object sender, EventArgs e)
        {
            InvoicesForm invoicesForm = new InvoicesForm();
            invoicesForm.ShowDialog();
            LoadDashboardData();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportsForm reportsForm = new ReportsForm();
            reportsForm.ShowDialog();
            LoadDashboardData();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            BackupRestoreForm backupForm = new BackupRestoreForm();
            backupForm.ShowDialog();
            LoadDashboardData();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpAboutForm helpForm = new HelpAboutForm();
            helpForm.ShowDialog();
            LoadDashboardData();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context?.Dispose();
        }

        private void btnParts_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var partsForm = new VehicleServiceManager.Forms.PartsForm())
            {
                partsForm.ShowDialog();
            }
            this.Show();
            LoadDashboardData();
        }

        private void btnVehicles_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var vehicleForm = new VehicleServiceManager.Forms.VehicleManagment())
            {
                vehicleForm.ShowDialog();
            }
            this.Show();
            LoadDashboardData();
        }

        private void btnErrorCodes_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var form = new VehicleServiceManager.Forms.ErrorCodesForm())
            {
                form.ShowDialog();
            }
            this.Show();
            LoadDashboardData();
        }
    }
}