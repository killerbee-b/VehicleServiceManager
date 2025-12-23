namespace VehicleServiceManager.Forms
{
    partial class InvoicesForm
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            pnlSearch = new Panel();
            btnRefresh = new Button();
            cmbStatusFilter = new ComboBox();
            lblStatusFilter = new Label();
            btnShowAll = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblSearchLabel = new Label();
            dataGridViewInvoices = new DataGridView();
            btnViewInvoice = new Button();
            btnPrintInvoice = new Button();
            btnUpdatePayment = new Button();
            lblTotalInvoices = new Label();
            btnClose = new Button();
            btnExportCsv = new Button();
            pnlHeader.SuspendLayout();
            pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInvoices).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(45, 45, 48);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1184, 80);
            pnlHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            lblSubtitle.BackColor = Color.Transparent;
            lblSubtitle.ForeColor = SystemColors.ScrollBar;
            lblSubtitle.Location = new Point(20, 50);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(400, 20);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Search and manage all generated invoices";
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(400, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "INVOICE MANAGEMENT";
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = Color.White;
            pnlSearch.BorderStyle = BorderStyle.FixedSingle;
            pnlSearch.Controls.Add(btnRefresh);
            pnlSearch.Controls.Add(cmbStatusFilter);
            pnlSearch.Controls.Add(lblStatusFilter);
            pnlSearch.Controls.Add(btnShowAll);
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(lblSearchLabel);
            pnlSearch.Location = new Point(20, 100);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(1160, 70);
            pnlSearch.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(117, 117, 117);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(1040, 10);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 30);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "🔄 Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // cmbStatusFilter
            // 
            cmbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatusFilter.FormattingEnabled = true;
            cmbStatusFilter.Location = new Point(870, 12);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new Size(150, 23);
            cmbStatusFilter.TabIndex = 5;
            // 
            // lblStatusFilter
            // 
            lblStatusFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatusFilter.Location = new Point(810, 15);
            lblStatusFilter.Name = "lblStatusFilter";
            lblStatusFilter.Size = new Size(50, 20);
            lblStatusFilter.TabIndex = 4;
            lblStatusFilter.Text = "Status:";
            // 
            // btnShowAll
            // 
            btnShowAll.BackColor = Color.FromArgb(96, 125, 139);
            btnShowAll.Cursor = Cursors.Hand;
            btnShowAll.FlatAppearance.BorderSize = 0;
            btnShowAll.FlatStyle = FlatStyle.Flat;
            btnShowAll.ForeColor = Color.White;
            btnShowAll.Location = new Point(650, 10);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(120, 30);
            btnShowAll.TabIndex = 3;
            btnShowAll.Text = "📋 Show All";
            btnShowAll.UseVisualStyleBackColor = false;
            btnShowAll.Click += btnShowAll_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(63, 81, 181);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(510, 10);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(120, 30);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "🔍 Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(90, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(400, 25);
            txtSearch.TabIndex = 1;
            txtSearch.Text = "Customer name, phone, VIN, license plate, or invoice number...";
            // 
            // lblSearchLabel
            // 
            lblSearchLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSearchLabel.Location = new Point(20, 15);
            lblSearchLabel.Name = "lblSearchLabel";
            lblSearchLabel.Size = new Size(60, 20);
            lblSearchLabel.TabIndex = 0;
            lblSearchLabel.Text = "Search:";
            // 
            // dataGridViewInvoices
            // 
            dataGridViewInvoices.AllowUserToAddRows = false;
            dataGridViewInvoices.AllowUserToDeleteRows = false;
            dataGridViewInvoices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewInvoices.BackgroundColor = Color.White;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(63, 81, 181);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridViewInvoices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewInvoices.ColumnHeadersHeight = 35;
            dataGridViewInvoices.Location = new Point(20, 190);
            dataGridViewInvoices.MultiSelect = false;
            dataGridViewInvoices.Name = "dataGridViewInvoices";
            dataGridViewInvoices.ReadOnly = true;
            dataGridViewInvoices.RowHeadersVisible = false;
            dataGridViewInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewInvoices.Size = new Size(1160, 380);
            dataGridViewInvoices.TabIndex = 2;
            // 
            // btnViewInvoice
            // 
            btnViewInvoice.BackColor = Color.FromArgb(0, 150, 136);
            btnViewInvoice.Cursor = Cursors.Hand;
            btnViewInvoice.Enabled = false;
            btnViewInvoice.FlatAppearance.BorderSize = 0;
            btnViewInvoice.FlatStyle = FlatStyle.Flat;
            btnViewInvoice.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewInvoice.ForeColor = Color.White;
            btnViewInvoice.Location = new Point(20, 590);
            btnViewInvoice.Name = "btnViewInvoice";
            btnViewInvoice.Size = new Size(160, 45);
            btnViewInvoice.TabIndex = 3;
            btnViewInvoice.Text = "📄 View Invoice";
            btnViewInvoice.UseVisualStyleBackColor = false;
            btnViewInvoice.Click += btnViewInvoice_Click;
            // 
            // btnPrintInvoice
            // 
            btnPrintInvoice.BackColor = Color.FromArgb(103, 58, 183);
            btnPrintInvoice.Cursor = Cursors.Hand;
            btnPrintInvoice.Enabled = false;
            btnPrintInvoice.FlatAppearance.BorderSize = 0;
            btnPrintInvoice.FlatStyle = FlatStyle.Flat;
            btnPrintInvoice.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPrintInvoice.ForeColor = Color.White;
            btnPrintInvoice.Location = new Point(200, 590);
            btnPrintInvoice.Name = "btnPrintInvoice";
            btnPrintInvoice.Size = new Size(140, 45);
            btnPrintInvoice.TabIndex = 4;
            btnPrintInvoice.Text = "🖨️ Print";
            btnPrintInvoice.UseVisualStyleBackColor = false;
            btnPrintInvoice.Click += btnPrintInvoice_Click;
            // 
            // btnUpdatePayment
            // 
            btnUpdatePayment.BackColor = Color.FromArgb(255, 152, 0);
            btnUpdatePayment.Cursor = Cursors.Hand;
            btnUpdatePayment.Enabled = false;
            btnUpdatePayment.FlatAppearance.BorderSize = 0;
            btnUpdatePayment.FlatStyle = FlatStyle.Flat;
            btnUpdatePayment.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUpdatePayment.ForeColor = Color.White;
            btnUpdatePayment.Location = new Point(360, 590);
            btnUpdatePayment.Name = "btnUpdatePayment";
            btnUpdatePayment.Size = new Size(180, 45);
            btnUpdatePayment.TabIndex = 5;
            btnUpdatePayment.Text = "💰 Update Payment";
            btnUpdatePayment.UseVisualStyleBackColor = false;
            btnUpdatePayment.Click += btnUpdatePayment_Click;
            // 
            // lblTotalInvoices
            // 
            lblTotalInvoices.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalInvoices.ForeColor = Color.FromArgb(63, 81, 181);
            lblTotalInvoices.Location = new Point(850, 605);
            lblTotalInvoices.Name = "lblTotalInvoices";
            lblTotalInvoices.Size = new Size(200, 20);
            lblTotalInvoices.TabIndex = 6;
            lblTotalInvoices.Text = "Total Invoices: 0";
            lblTotalInvoices.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(189, 189, 189);
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.FromArgb(60, 60, 60);
            btnClose.Location = new Point(1060, 590);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(120, 45);
            btnClose.TabIndex = 7;
            btnClose.Text = "✖ Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnExportCsv
            // 
            btnExportCsv.BackColor = Color.FromArgb(52, 152, 219);
            btnExportCsv.Cursor = Cursors.Hand;
            btnExportCsv.Enabled = false;
            btnExportCsv.FlatAppearance.BorderSize = 0;
            btnExportCsv.FlatStyle = FlatStyle.Flat;
            btnExportCsv.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExportCsv.ForeColor = Color.White;
            btnExportCsv.Location = new Point(560, 590);
            btnExportCsv.Name = "btnExportCsv";
            btnExportCsv.Size = new Size(180, 45);
            btnExportCsv.TabIndex = 8;
            btnExportCsv.Text = "📊 Export to CSV";
            btnExportCsv.UseVisualStyleBackColor = false;
            btnExportCsv.Click += btnExportCsv_Click;
            // 
            // InvoicesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1184, 661);
            Controls.Add(btnExportCsv);
            Controls.Add(btnClose);
            Controls.Add(lblTotalInvoices);
            Controls.Add(btnUpdatePayment);
            Controls.Add(btnPrintInvoice);
            Controls.Add(btnViewInvoice);
            Controls.Add(dataGridViewInvoices);
            Controls.Add(pnlSearch);
            Controls.Add(pnlHeader);
            Name = "InvoicesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Invoice Management - AUTO B&T";
            Load += InvoicesForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInvoices).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblSubtitle;
        private Label lblTitle;
        private Panel pnlSearch;
        private Label lblSearchLabel;
        private Button btnSearch;
        private TextBox txtSearch;
        private Button btnShowAll;
        private Label lblStatusFilter;
        private ComboBox cmbStatusFilter;
        private Button btnRefresh;
        private DataGridView dataGridViewInvoices;
        private Button btnViewInvoice;
        private Button btnPrintInvoice;
        private Button btnUpdatePayment;
        private Label lblTotalInvoices;
        private Button btnClose;
        private Button btnExportCsv;
    }
}