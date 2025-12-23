namespace VehicleServiceManager.Forms
{
    partial class ReportsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblTitle = new Label();
            groupBoxReportType = new GroupBox();
            btnLowStock = new Button();
            btnCustomerHistory = new Button();
            btnMonthlyRevenue = new Button();
            groupBoxDateRange = new GroupBox();
            dtpToDate = new DateTimePicker();
            lblToDate = new Label();
            dtpFromDate = new DateTimePicker();
            lblFromDate = new Label();
            dataGridViewReport = new DataGridView();
            btnExportPdf = new Button();
            btnExportCsv = new Button();
            btnPrint = new Button();
            btnClose = new Button();
            lblReportTitle = new Label();
            panelHeader.SuspendLayout();
            groupBoxReportType.SuspendLayout();
            groupBoxDateRange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReport).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(44, 62, 80);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1184, 70);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(322, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📊 REPORTS && ANALYTICS";
            // 
            // groupBoxReportType
            // 
            groupBoxReportType.Controls.Add(btnLowStock);
            groupBoxReportType.Controls.Add(btnCustomerHistory);
            groupBoxReportType.Controls.Add(btnMonthlyRevenue);
            groupBoxReportType.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxReportType.Location = new Point(20, 100);
            groupBoxReportType.Name = "groupBoxReportType";
            groupBoxReportType.Size = new Size(280, 220);
            groupBoxReportType.TabIndex = 1;
            groupBoxReportType.TabStop = false;
            groupBoxReportType.Text = "Select Report Type";
            // 
            // btnLowStock
            // 
            btnLowStock.BackColor = Color.FromArgb(231, 76, 60);
            btnLowStock.FlatStyle = FlatStyle.Flat;
            btnLowStock.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLowStock.ForeColor = Color.White;
            btnLowStock.Location = new Point(20, 145);
            btnLowStock.Name = "btnLowStock";
            btnLowStock.Size = new Size(240, 45);
            btnLowStock.TabIndex = 2;
            btnLowStock.Text = "⚠️ Parts Low Stock Alert";
            btnLowStock.UseVisualStyleBackColor = false;
            btnLowStock.Click += btnLowStock_Click;
            // 
            // btnCustomerHistory
            // 
            btnCustomerHistory.BackColor = Color.FromArgb(52, 152, 219);
            btnCustomerHistory.FlatStyle = FlatStyle.Flat;
            btnCustomerHistory.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCustomerHistory.ForeColor = Color.White;
            btnCustomerHistory.Location = new Point(20, 90);
            btnCustomerHistory.Name = "btnCustomerHistory";
            btnCustomerHistory.Size = new Size(240, 45);
            btnCustomerHistory.TabIndex = 1;
            btnCustomerHistory.Text = "👥 Customer Service History";
            btnCustomerHistory.UseVisualStyleBackColor = false;
            btnCustomerHistory.Click += btnCustomerHistory_Click;
            // 
            // btnMonthlyRevenue
            // 
            btnMonthlyRevenue.BackColor = Color.FromArgb(46, 204, 113);
            btnMonthlyRevenue.FlatStyle = FlatStyle.Flat;
            btnMonthlyRevenue.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMonthlyRevenue.ForeColor = Color.White;
            btnMonthlyRevenue.Location = new Point(20, 35);
            btnMonthlyRevenue.Name = "btnMonthlyRevenue";
            btnMonthlyRevenue.Size = new Size(240, 45);
            btnMonthlyRevenue.TabIndex = 0;
            btnMonthlyRevenue.Text = "💰 Monthly Revenue Report";
            btnMonthlyRevenue.UseVisualStyleBackColor = false;
            btnMonthlyRevenue.Click += btnMonthlyRevenue_Click;
            // 
            // groupBoxDateRange
            // 
            groupBoxDateRange.Controls.Add(dtpToDate);
            groupBoxDateRange.Controls.Add(lblToDate);
            groupBoxDateRange.Controls.Add(dtpFromDate);
            groupBoxDateRange.Controls.Add(lblFromDate);
            groupBoxDateRange.Location = new Point(20, 340);
            groupBoxDateRange.Name = "groupBoxDateRange";
            groupBoxDateRange.Size = new Size(280, 160);
            groupBoxDateRange.TabIndex = 2;
            groupBoxDateRange.TabStop = false;
            groupBoxDateRange.Text = "Date Range (for Revenue Report)";
            // 
            // dtpToDate
            // 
            dtpToDate.Location = new Point(20, 120);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(240, 23);
            dtpToDate.TabIndex = 3;
            dtpToDate.Value = new DateTime(2025, 12, 22, 0, 0, 0, 0);
            // 
            // lblToDate
            // 
            lblToDate.AutoSize = true;
            lblToDate.Location = new Point(20, 95);
            lblToDate.Name = "lblToDate";
            lblToDate.Size = new Size(50, 15);
            lblToDate.TabIndex = 2;
            lblToDate.Text = "To Date:";
            // 
            // dtpFromDate
            // 
            dtpFromDate.Location = new Point(20, 60);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(240, 23);
            dtpFromDate.TabIndex = 1;
            dtpFromDate.Value = new DateTime(2025, 6, 1, 0, 0, 0, 0);
            // 
            // lblFromDate
            // 
            lblFromDate.AutoSize = true;
            lblFromDate.Location = new Point(20, 35);
            lblFromDate.Name = "lblFromDate";
            lblFromDate.Size = new Size(65, 15);
            lblFromDate.TabIndex = 0;
            lblFromDate.Text = "From Date:";
            // 
            // dataGridViewReport
            // 
            dataGridViewReport.AllowUserToAddRows = false;
            dataGridViewReport.AllowUserToDeleteRows = false;
            dataGridViewReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewReport.BackgroundColor = Color.White;
            dataGridViewReport.BorderStyle = BorderStyle.None;
            dataGridViewReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReport.Location = new Point(320, 100);
            dataGridViewReport.Name = "dataGridViewReport";
            dataGridViewReport.ReadOnly = true;
            dataGridViewReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewReport.Size = new Size(850, 500);
            dataGridViewReport.TabIndex = 3;
            // 
            // btnExportPdf
            // 
            btnExportPdf.BackColor = Color.FromArgb(230, 126, 34);
            btnExportPdf.Enabled = false;
            btnExportPdf.FlatStyle = FlatStyle.Flat;
            btnExportPdf.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExportPdf.ForeColor = Color.White;
            btnExportPdf.Location = new Point(320, 620);
            btnExportPdf.Name = "btnExportPdf";
            btnExportPdf.Size = new Size(150, 40);
            btnExportPdf.TabIndex = 4;
            btnExportPdf.Text = "📄 Export to PDF";
            btnExportPdf.UseVisualStyleBackColor = false;
            btnExportPdf.Click += btnExportPdf_Click;
            // 
            // btnExportCsv
            // 
            btnExportCsv.BackColor = Color.FromArgb(52, 152, 219);
            btnExportCsv.Enabled = false;
            btnExportCsv.FlatStyle = FlatStyle.Flat;
            btnExportCsv.ForeColor = Color.White;
            btnExportCsv.Location = new Point(490, 620);
            btnExportCsv.Name = "btnExportCsv";
            btnExportCsv.Size = new Size(150, 40);
            btnExportCsv.TabIndex = 5;
            btnExportCsv.Text = "📊 Export to CSV";
            btnExportCsv.UseVisualStyleBackColor = false;
            btnExportCsv.Click += btnExportCsv_Click;
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.FromArgb(149, 165, 166);
            btnPrint.Enabled = false;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(660, 620);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(150, 40);
            btnPrint.TabIndex = 6;
            btnPrint.Text = "🖨️ Print";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(189, 195, 199);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1020, 620);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(150, 40);
            btnClose.TabIndex = 7;
            btnClose.Text = "✖ Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // lblReportTitle
            // 
            lblReportTitle.AutoSize = true;
            lblReportTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblReportTitle.ForeColor = Color.FromArgb(52, 73, 94);
            lblReportTitle.Location = new Point(320, 70);
            lblReportTitle.Name = "lblReportTitle";
            lblReportTitle.Size = new Size(180, 21);
            lblReportTitle.TabIndex = 8;
            lblReportTitle.Text = "Select a report to view";
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1184, 711);
            Controls.Add(lblReportTitle);
            Controls.Add(btnClose);
            Controls.Add(btnPrint);
            Controls.Add(btnExportCsv);
            Controls.Add(btnExportPdf);
            Controls.Add(dataGridViewReport);
            Controls.Add(groupBoxDateRange);
            Controls.Add(groupBoxReportType);
            Controls.Add(panelHeader);
            Name = "ReportsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reports & Analytics - AUTO B&T";
            Load += ReportsForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            groupBoxReportType.ResumeLayout(false);
            groupBoxDateRange.ResumeLayout(false);
            groupBoxDateRange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitle;
        private GroupBox groupBoxReportType;
        private Button btnLowStock;
        private Button btnCustomerHistory;
        private Button btnMonthlyRevenue;
        private GroupBox groupBoxDateRange;
        private DateTimePicker dtpFromDate;
        private Label lblFromDate;
        private Label lblToDate;
        private DateTimePicker dtpToDate;
        private DataGridView dataGridViewReport;
        private Button btnExportPdf;
        private Button btnExportCsv;
        private Button btnPrint;
        private Button btnClose;
        private Label lblReportTitle;
    }
}