namespace VehicleServiceManager
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelNavigation = new Panel();
            btnErrorCodes = new Button();
            btnBackupRestore = new Button();
            btnReports = new Button();
            btnInvoices = new Button();
            btnHelp = new Button();
            btnParts = new Button();
            btnServiceOrders = new Button();
            btnVehicles = new Button();
            btnCustomers = new Button();
            panelLabel = new Panel();
            groupBoxRecentActivity = new GroupBox();
            listBoxRecentActivity = new ListBox();
            panelCharts = new Panel();
            panelKPICards = new Panel();
            panelRevenueKPI = new Panel();
            lblRevenueLabel = new Label();
            lblRevenueAmount = new Label();
            panelOrdersKPI = new Panel();
            lblOrdersLabel = new Label();
            lblOrdersCount = new Label();
            panelVehiclesKPI = new Panel();
            lblVehiclesLabel = new Label();
            lblVehiclesCount = new Label();
            panelCustomersKPI = new Panel();
            lblCustomersLabel = new Label();
            lblCustomersCount = new Label();
            lblWelcome = new Label();
            panelNavigation.SuspendLayout();
            panelLabel.SuspendLayout();
            groupBoxRecentActivity.SuspendLayout();
            panelKPICards.SuspendLayout();
            panelRevenueKPI.SuspendLayout();
            panelOrdersKPI.SuspendLayout();
            panelVehiclesKPI.SuspendLayout();
            panelCustomersKPI.SuspendLayout();
            SuspendLayout();
            // 
            // panelNavigation
            // 
            panelNavigation.BackColor = Color.DarkSlateGray;
            panelNavigation.Controls.Add(btnErrorCodes);
            panelNavigation.Controls.Add(btnBackupRestore);
            panelNavigation.Controls.Add(btnReports);
            panelNavigation.Controls.Add(btnInvoices);
            panelNavigation.Controls.Add(btnHelp);
            panelNavigation.Controls.Add(btnParts);
            panelNavigation.Controls.Add(btnServiceOrders);
            panelNavigation.Controls.Add(btnVehicles);
            panelNavigation.Controls.Add(btnCustomers);
            panelNavigation.Dock = DockStyle.Left;
            panelNavigation.Location = new Point(0, 0);
            panelNavigation.Name = "panelNavigation";
            panelNavigation.Size = new Size(200, 661);
            panelNavigation.TabIndex = 0;
            // 
            // btnErrorCodes
            // 
            btnErrorCodes.BackColor = Color.Transparent;
            btnErrorCodes.FlatStyle = FlatStyle.Flat;
            btnErrorCodes.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnErrorCodes.ForeColor = Color.White;
            btnErrorCodes.Location = new Point(10, 380);
            btnErrorCodes.Name = "btnErrorCodes";
            btnErrorCodes.Size = new Size(180, 50);
            btnErrorCodes.TabIndex = 8;
            btnErrorCodes.Text = "\U0001f9f0 Error Codes / Diagnostics";
            btnErrorCodes.UseVisualStyleBackColor = false;
            btnErrorCodes.Click += btnErrorCodes_Click;
            // 
            // btnBackupRestore
            // 
            btnBackupRestore.BackColor = Color.Transparent;
            btnBackupRestore.FlatStyle = FlatStyle.Flat;
            btnBackupRestore.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnBackupRestore.ForeColor = Color.White;
            btnBackupRestore.Location = new Point(10, 540);
            btnBackupRestore.Name = "btnBackupRestore";
            btnBackupRestore.Size = new Size(180, 50);
            btnBackupRestore.TabIndex = 7;
            btnBackupRestore.Text = "🔄 Backup/Restore";
            btnBackupRestore.UseVisualStyleBackColor = false;
            btnBackupRestore.Click += btnBackup_Click;
            // 
            // btnReports
            // 
            btnReports.BackColor = Color.Transparent;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnReports.ForeColor = Color.White;
            btnReports.Location = new Point(10, 320);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(180, 50);
            btnReports.TabIndex = 6;
            btnReports.Text = "📈 Reports";
            btnReports.UseVisualStyleBackColor = false;
            btnReports.Click += btnReports_Click;
            // 
            // btnInvoices
            // 
            btnInvoices.BackColor = Color.Transparent;
            btnInvoices.FlatStyle = FlatStyle.Flat;
            btnInvoices.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnInvoices.ForeColor = Color.White;
            btnInvoices.Location = new Point(10, 260);
            btnInvoices.Name = "btnInvoices";
            btnInvoices.Size = new Size(180, 50);
            btnInvoices.TabIndex = 5;
            btnInvoices.Text = "📄 Invoices";
            btnInvoices.UseVisualStyleBackColor = false;
            btnInvoices.Click += btnInvoices_Click;
            // 
            // btnHelp
            // 
            btnHelp.BackColor = Color.Transparent;
            btnHelp.FlatStyle = FlatStyle.Flat;
            btnHelp.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnHelp.ForeColor = Color.White;
            btnHelp.Location = new Point(10, 600);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(180, 50);
            btnHelp.TabIndex = 4;
            btnHelp.Text = "❓ Help / About";
            btnHelp.UseVisualStyleBackColor = false;
            btnHelp.Click += btnHelp_Click;
            // 
            // btnParts
            // 
            btnParts.BackColor = Color.Transparent;
            btnParts.FlatStyle = FlatStyle.Flat;
            btnParts.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnParts.ForeColor = Color.White;
            btnParts.Location = new Point(10, 200);
            btnParts.Name = "btnParts";
            btnParts.Size = new Size(180, 50);
            btnParts.TabIndex = 0;
            btnParts.Text = "📦 Parts Inventory";
            btnParts.UseVisualStyleBackColor = false;
            btnParts.Click += btnParts_Click;
            // 
            // btnServiceOrders
            // 
            btnServiceOrders.BackColor = Color.Transparent;
            btnServiceOrders.FlatStyle = FlatStyle.Flat;
            btnServiceOrders.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnServiceOrders.ForeColor = Color.White;
            btnServiceOrders.Location = new Point(10, 140);
            btnServiceOrders.Name = "btnServiceOrders";
            btnServiceOrders.Size = new Size(180, 50);
            btnServiceOrders.TabIndex = 3;
            btnServiceOrders.Text = "🔧 Service Orders";
            btnServiceOrders.UseVisualStyleBackColor = false;
            btnServiceOrders.Click += btnServiceOrders_Click;
            // 
            // btnVehicles
            // 
            btnVehicles.BackColor = Color.Transparent;
            btnVehicles.FlatStyle = FlatStyle.Flat;
            btnVehicles.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVehicles.ForeColor = Color.White;
            btnVehicles.Location = new Point(10, 80);
            btnVehicles.Name = "btnVehicles";
            btnVehicles.Size = new Size(180, 50);
            btnVehicles.TabIndex = 2;
            btnVehicles.Text = "🚗 Vehicles";
            btnVehicles.UseVisualStyleBackColor = false;
            btnVehicles.Click += btnVehicles_Click;
            // 
            // btnCustomers
            // 
            btnCustomers.BackColor = Color.Transparent;
            btnCustomers.FlatStyle = FlatStyle.Flat;
            btnCustomers.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCustomers.ForeColor = Color.White;
            btnCustomers.Location = new Point(10, 20);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Size = new Size(180, 50);
            btnCustomers.TabIndex = 1;
            btnCustomers.Text = "👤 Customers";
            btnCustomers.UseVisualStyleBackColor = false;
            btnCustomers.Click += btnCustomers_Click;
            // 
            // panelLabel
            // 
            panelLabel.BackColor = Color.WhiteSmoke;
            panelLabel.Controls.Add(groupBoxRecentActivity);
            panelLabel.Controls.Add(panelCharts);
            panelLabel.Controls.Add(panelKPICards);
            panelLabel.Controls.Add(lblWelcome);
            panelLabel.Dock = DockStyle.Fill;
            panelLabel.Location = new Point(200, 0);
            panelLabel.Name = "panelLabel";
            panelLabel.Size = new Size(984, 661);
            panelLabel.TabIndex = 1;
            // 
            // groupBoxRecentActivity
            // 
            groupBoxRecentActivity.Controls.Add(listBoxRecentActivity);
            groupBoxRecentActivity.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxRecentActivity.ForeColor = Color.DarkSlateGray;
            groupBoxRecentActivity.Location = new Point(30, 540);
            groupBoxRecentActivity.Name = "groupBoxRecentActivity";
            groupBoxRecentActivity.Size = new Size(920, 115);
            groupBoxRecentActivity.TabIndex = 3;
            groupBoxRecentActivity.TabStop = false;
            groupBoxRecentActivity.Text = "📋 Recent Activity";
            // 
            // listBoxRecentActivity
            // 
            listBoxRecentActivity.BackColor = Color.WhiteSmoke;
            listBoxRecentActivity.ForeColor = Color.DimGray;
            listBoxRecentActivity.FormattingEnabled = true;
            listBoxRecentActivity.Location = new Point(10, 30);
            listBoxRecentActivity.Name = "listBoxRecentActivity";
            listBoxRecentActivity.SelectionMode = SelectionMode.None;
            listBoxRecentActivity.Size = new Size(900, 84);
            listBoxRecentActivity.TabIndex = 0;
            // 
            // panelCharts
            // 
            panelCharts.BackColor = Color.Transparent;
            panelCharts.Location = new Point(30, 220);
            panelCharts.Name = "panelCharts";
            panelCharts.Size = new Size(920, 300);
            panelCharts.TabIndex = 2;
            // 
            // panelKPICards
            // 
            panelKPICards.BackColor = Color.Transparent;
            panelKPICards.Controls.Add(panelRevenueKPI);
            panelKPICards.Controls.Add(panelOrdersKPI);
            panelKPICards.Controls.Add(panelVehiclesKPI);
            panelKPICards.Controls.Add(panelCustomersKPI);
            panelKPICards.Location = new Point(30, 80);
            panelKPICards.Name = "panelKPICards";
            panelKPICards.Size = new Size(920, 120);
            panelKPICards.TabIndex = 1;
            // 
            // panelRevenueKPI
            // 
            panelRevenueKPI.BackColor = Color.MediumPurple;
            panelRevenueKPI.Controls.Add(lblRevenueLabel);
            panelRevenueKPI.Controls.Add(lblRevenueAmount);
            panelRevenueKPI.Location = new Point(705, 0);
            panelRevenueKPI.Name = "panelRevenueKPI";
            panelRevenueKPI.Size = new Size(215, 100);
            panelRevenueKPI.TabIndex = 3;
            // 
            // lblRevenueLabel
            // 
            lblRevenueLabel.AutoSize = true;
            lblRevenueLabel.BackColor = Color.Transparent;
            lblRevenueLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRevenueLabel.ForeColor = Color.White;
            lblRevenueLabel.Location = new Point(20, 60);
            lblRevenueLabel.Name = "lblRevenueLabel";
            lblRevenueLabel.Size = new Size(111, 17);
            lblRevenueLabel.TabIndex = 1;
            lblRevenueLabel.Text = "💰 Total Revenue";
            // 
            // lblRevenueAmount
            // 
            lblRevenueAmount.AutoSize = true;
            lblRevenueAmount.BackColor = Color.Transparent;
            lblRevenueAmount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRevenueAmount.ForeColor = Color.White;
            lblRevenueAmount.Location = new Point(20, 15);
            lblRevenueAmount.Name = "lblRevenueAmount";
            lblRevenueAmount.Size = new Size(101, 45);
            lblRevenueAmount.TabIndex = 0;
            lblRevenueAmount.Text = "€0.00";
            // 
            // panelOrdersKPI
            // 
            panelOrdersKPI.BackColor = Color.Orange;
            panelOrdersKPI.Controls.Add(lblOrdersLabel);
            panelOrdersKPI.Controls.Add(lblOrdersCount);
            panelOrdersKPI.Location = new Point(470, 0);
            panelOrdersKPI.Name = "panelOrdersKPI";
            panelOrdersKPI.Size = new Size(220, 100);
            panelOrdersKPI.TabIndex = 2;
            // 
            // lblOrdersLabel
            // 
            lblOrdersLabel.AutoSize = true;
            lblOrdersLabel.BackColor = Color.Transparent;
            lblOrdersLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOrdersLabel.ForeColor = Color.White;
            lblOrdersLabel.Location = new Point(20, 60);
            lblOrdersLabel.Name = "lblOrdersLabel";
            lblOrdersLabel.Size = new Size(109, 17);
            lblOrdersLabel.TabIndex = 1;
            lblOrdersLabel.Text = "🔧 Active Orders";
            // 
            // lblOrdersCount
            // 
            lblOrdersCount.AutoSize = true;
            lblOrdersCount.BackColor = Color.Transparent;
            lblOrdersCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOrdersCount.ForeColor = Color.White;
            lblOrdersCount.Location = new Point(20, 15);
            lblOrdersCount.Name = "lblOrdersCount";
            lblOrdersCount.Size = new Size(38, 45);
            lblOrdersCount.TabIndex = 0;
            lblOrdersCount.Text = "0";
            // 
            // panelVehiclesKPI
            // 
            panelVehiclesKPI.BackColor = Color.DodgerBlue;
            panelVehiclesKPI.Controls.Add(lblVehiclesLabel);
            panelVehiclesKPI.Controls.Add(lblVehiclesCount);
            panelVehiclesKPI.Location = new Point(235, 0);
            panelVehiclesKPI.Name = "panelVehiclesKPI";
            panelVehiclesKPI.Size = new Size(220, 100);
            panelVehiclesKPI.TabIndex = 1;
            // 
            // lblVehiclesLabel
            // 
            lblVehiclesLabel.AutoSize = true;
            lblVehiclesLabel.BackColor = Color.Transparent;
            lblVehiclesLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVehiclesLabel.ForeColor = Color.White;
            lblVehiclesLabel.Location = new Point(20, 60);
            lblVehiclesLabel.Name = "lblVehiclesLabel";
            lblVehiclesLabel.Size = new Size(108, 17);
            lblVehiclesLabel.TabIndex = 1;
            lblVehiclesLabel.Text = "🚗 Total Vehicles";
            // 
            // lblVehiclesCount
            // 
            lblVehiclesCount.AutoSize = true;
            lblVehiclesCount.BackColor = Color.Transparent;
            lblVehiclesCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVehiclesCount.ForeColor = Color.White;
            lblVehiclesCount.Location = new Point(20, 15);
            lblVehiclesCount.Name = "lblVehiclesCount";
            lblVehiclesCount.Size = new Size(38, 45);
            lblVehiclesCount.TabIndex = 0;
            lblVehiclesCount.Text = "0";
            // 
            // panelCustomersKPI
            // 
            panelCustomersKPI.BackColor = Color.MediumSeaGreen;
            panelCustomersKPI.Controls.Add(lblCustomersLabel);
            panelCustomersKPI.Controls.Add(lblCustomersCount);
            panelCustomersKPI.Location = new Point(0, 0);
            panelCustomersKPI.Name = "panelCustomersKPI";
            panelCustomersKPI.Size = new Size(220, 100);
            panelCustomersKPI.TabIndex = 0;
            // 
            // lblCustomersLabel
            // 
            lblCustomersLabel.AutoSize = true;
            lblCustomersLabel.BackColor = Color.Transparent;
            lblCustomersLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomersLabel.ForeColor = Color.White;
            lblCustomersLabel.Location = new Point(20, 60);
            lblCustomersLabel.Name = "lblCustomersLabel";
            lblCustomersLabel.Size = new Size(124, 17);
            lblCustomersLabel.TabIndex = 1;
            lblCustomersLabel.Text = "👤 Total Customers";
            // 
            // lblCustomersCount
            // 
            lblCustomersCount.AutoSize = true;
            lblCustomersCount.BackColor = Color.Transparent;
            lblCustomersCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCustomersCount.ForeColor = Color.White;
            lblCustomersCount.Location = new Point(20, 15);
            lblCustomersCount.Name = "lblCustomersCount";
            lblCustomersCount.Size = new Size(38, 45);
            lblCustomersCount.TabIndex = 0;
            lblCustomersCount.Text = "0";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = Color.DarkSlateGray;
            lblWelcome.Location = new Point(30, 20);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(332, 37);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "DASHBOARD OVERVIEW";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 661);
            Controls.Add(panelLabel);
            Controls.Add(panelNavigation);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Vehicle Service Management System";
            Load += MainForm_Load;
            panelNavigation.ResumeLayout(false);
            panelLabel.ResumeLayout(false);
            panelLabel.PerformLayout();
            groupBoxRecentActivity.ResumeLayout(false);
            panelKPICards.ResumeLayout(false);
            panelRevenueKPI.ResumeLayout(false);
            panelRevenueKPI.PerformLayout();
            panelOrdersKPI.ResumeLayout(false);
            panelOrdersKPI.PerformLayout();
            panelVehiclesKPI.ResumeLayout(false);
            panelVehiclesKPI.PerformLayout();
            panelCustomersKPI.ResumeLayout(false);
            panelCustomersKPI.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelNavigation;
        private Panel panelLabel;
        private Button btnCustomers;
        private Button btnParts;
        private Button btnServiceOrders;
        private Button btnVehicles;
        private Button btnHelp;
        private Label lblWelcome;
        private Button btnInvoices;
        private Button btnReports;
        private Button btnBackupRestore;
        private Panel panelKPICards;
        private Panel panelVehiclesKPI;
        private Panel panelCustomersKPI;
        private Label lblCustomersLabel;
        private Label lblCustomersCount;
        private Label lblVehiclesLabel;
        private Label lblVehiclesCount;
        private Panel panelOrdersKPI;
        private Label lblOrdersLabel;
        private Label lblOrdersCount;
        private Panel panelRevenueKPI;
        private Label lblRevenueLabel;
        private Label lblRevenueAmount;
        private Panel panelCharts;
        private GroupBox groupBoxRecentActivity;
        private ListBox listBoxRecentActivity;
        private Button btnErrorCodes;
    }
}
