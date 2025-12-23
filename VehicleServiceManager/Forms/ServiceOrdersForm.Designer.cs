namespace VehicleServiceManager.Forms
{
    partial class ServiceOrdersForm
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
            components = new System.ComponentModel.Container();
            lblCustomer = new Label();
            cmbCustomers = new ComboBox();
            lblVehicle = new Label();
            cmbVehicles = new ComboBox();
            dataGridViewOrders = new DataGridView();
            statusFilter = new Label();
            cmbStatusFilter = new ComboBox();
            btnSearch = new Button();
            btnShowAll = new Button();
            btnRefresh = new Button();
            groupBoxDetails = new GroupBox();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            txtNotes = new TextBox();
            lblNotes = new Label();
            chkMarkCompleted = new CheckBox();
            dtpCompletedDate = new DateTimePicker();
            lblCompletedDate = new Label();
            txtTotalCost = new TextBox();
            lblTotalCost = new Label();
            numLaborRate = new NumericUpDown();
            lblLaborRate = new Label();
            numLaborHours = new NumericUpDown();
            lblLaborHours = new Label();
            txtDescription = new TextBox();
            lblDescription = new Label();
            cmbStatus = new ComboBox();
            lblStatus = new Label();
            dtpServiceDate = new DateTimePicker();
            lblServiceDate = new Label();
            errorProvider1 = new ErrorProvider(components);
            btnViewInvoice = new Button();
            btnExportCsv = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).BeginInit();
            groupBoxDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numLaborRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numLaborHours).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCustomer.Location = new Point(23, 27);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(93, 23);
            lblCustomer.TabIndex = 0;
            lblCustomer.Text = "Customer:";
            // 
            // cmbCustomers
            // 
            cmbCustomers.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCustomers.FormattingEnabled = true;
            cmbCustomers.Location = new Point(109, 23);
            cmbCustomers.Margin = new Padding(3, 4, 3, 4);
            cmbCustomers.Name = "cmbCustomers";
            cmbCustomers.Size = new Size(251, 28);
            cmbCustomers.TabIndex = 1;
            // 
            // lblVehicle
            // 
            lblVehicle.AutoSize = true;
            lblVehicle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblVehicle.Location = new Point(457, 27);
            lblVehicle.Name = "lblVehicle";
            lblVehicle.Size = new Size(71, 23);
            lblVehicle.TabIndex = 2;
            lblVehicle.Text = "Vehicle:";
            // 
            // cmbVehicles
            // 
            cmbVehicles.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVehicles.FormattingEnabled = true;
            cmbVehicles.Location = new Point(526, 23);
            cmbVehicles.Margin = new Padding(3, 4, 3, 4);
            cmbVehicles.Name = "cmbVehicles";
            cmbVehicles.Size = new Size(251, 28);
            cmbVehicles.TabIndex = 3;
            // 
            // dataGridViewOrders
            // 
            dataGridViewOrders.AllowUserToAddRows = false;
            dataGridViewOrders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOrders.Location = new Point(23, 133);
            dataGridViewOrders.Margin = new Padding(3, 4, 3, 4);
            dataGridViewOrders.MultiSelect = false;
            dataGridViewOrders.Name = "dataGridViewOrders";
            dataGridViewOrders.ReadOnly = true;
            dataGridViewOrders.RowHeadersWidth = 51;
            dataGridViewOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewOrders.Size = new Size(1314, 307);
            dataGridViewOrders.TabIndex = 4;
            // 
            // statusFilter
            // 
            statusFilter.AutoSize = true;
            statusFilter.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            statusFilter.Location = new Point(971, 27);
            statusFilter.Name = "statusFilter";
            statusFilter.Size = new Size(65, 23);
            statusFilter.TabIndex = 5;
            statusFilter.Text = "Status:";
            // 
            // cmbStatusFilter
            // 
            cmbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatusFilter.FormattingEnabled = true;
            cmbStatusFilter.Location = new Point(1040, 23);
            cmbStatusFilter.Margin = new Padding(3, 4, 3, 4);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new Size(251, 28);
            cmbStatusFilter.TabIndex = 6;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.LightSteelBlue;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.Location = new Point(23, 73);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(114, 40);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "🔍 Filter";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnShowAll
            // 
            btnShowAll.BackColor = Color.LightSteelBlue;
            btnShowAll.FlatStyle = FlatStyle.Flat;
            btnShowAll.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnShowAll.Location = new Point(149, 73);
            btnShowAll.Margin = new Padding(3, 4, 3, 4);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(114, 40);
            btnShowAll.TabIndex = 8;
            btnShowAll.Text = "↻ Show All";
            btnShowAll.UseVisualStyleBackColor = false;
            btnShowAll.Click += btnShowAll_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.LightSteelBlue;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.Location = new Point(274, 73);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(114, 40);
            btnRefresh.TabIndex = 9;
            btnRefresh.Text = "🔄 Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // groupBoxDetails
            // 
            groupBoxDetails.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxDetails.Controls.Add(btnClear);
            groupBoxDetails.Controls.Add(btnDelete);
            groupBoxDetails.Controls.Add(btnUpdate);
            groupBoxDetails.Controls.Add(btnAdd);
            groupBoxDetails.Controls.Add(txtNotes);
            groupBoxDetails.Controls.Add(lblNotes);
            groupBoxDetails.Controls.Add(chkMarkCompleted);
            groupBoxDetails.Controls.Add(dtpCompletedDate);
            groupBoxDetails.Controls.Add(lblCompletedDate);
            groupBoxDetails.Controls.Add(txtTotalCost);
            groupBoxDetails.Controls.Add(lblTotalCost);
            groupBoxDetails.Controls.Add(numLaborRate);
            groupBoxDetails.Controls.Add(lblLaborRate);
            groupBoxDetails.Controls.Add(numLaborHours);
            groupBoxDetails.Controls.Add(lblLaborHours);
            groupBoxDetails.Controls.Add(txtDescription);
            groupBoxDetails.Controls.Add(lblDescription);
            groupBoxDetails.Controls.Add(cmbStatus);
            groupBoxDetails.Controls.Add(lblStatus);
            groupBoxDetails.Controls.Add(dtpServiceDate);
            groupBoxDetails.Controls.Add(lblServiceDate);
            groupBoxDetails.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxDetails.Location = new Point(23, 453);
            groupBoxDetails.Margin = new Padding(3, 4, 3, 4);
            groupBoxDetails.Name = "groupBoxDetails";
            groupBoxDetails.Padding = new Padding(3, 4, 3, 4);
            groupBoxDetails.Size = new Size(1314, 400);
            groupBoxDetails.TabIndex = 10;
            groupBoxDetails.TabStop = false;
            groupBoxDetails.Text = "Service Order Details";
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.LightGray;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Location = new Point(1006, 300);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(171, 73);
            btnClear.TabIndex = 20;
            btnClear.Text = "🔄 Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.LightCoral;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(1006, 213);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(171, 73);
            btnDelete.TabIndex = 19;
            btnDelete.Text = "🗑️ Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.DeepSkyBlue;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Location = new Point(1006, 127);
            btnUpdate.Margin = new Padding(3, 4, 3, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(171, 73);
            btnUpdate.TabIndex = 18;
            btnUpdate.Text = "📝 Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.LightGreen;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Location = new Point(1006, 40);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(171, 73);
            btnAdd.TabIndex = 17;
            btnAdd.Text = "➕ Add New";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(137, 283);
            txtNotes.Margin = new Padding(3, 4, 3, 4);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.ScrollBars = ScrollBars.Vertical;
            txtNotes.Size = new Size(685, 79);
            txtNotes.TabIndex = 16;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNotes.Location = new Point(17, 287);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(51, 20);
            lblNotes.TabIndex = 15;
            lblNotes.Text = "Notes:";
            // 
            // chkMarkCompleted
            // 
            chkMarkCompleted.AutoSize = true;
            chkMarkCompleted.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkMarkCompleted.Location = new Point(400, 231);
            chkMarkCompleted.Margin = new Padding(3, 4, 3, 4);
            chkMarkCompleted.Name = "chkMarkCompleted";
            chkMarkCompleted.Size = new Size(192, 24);
            chkMarkCompleted.TabIndex = 14;
            chkMarkCompleted.Text = "✅ Mark as Completed";
            chkMarkCompleted.UseVisualStyleBackColor = true;
            chkMarkCompleted.CheckedChanged += chkMarkCompleted_CheckedChanged;
            // 
            // dtpCompletedDate
            // 
            dtpCompletedDate.Enabled = false;
            dtpCompletedDate.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpCompletedDate.Format = DateTimePickerFormat.Short;
            dtpCompletedDate.Location = new Point(137, 229);
            dtpCompletedDate.Margin = new Padding(3, 4, 3, 4);
            dtpCompletedDate.Name = "dtpCompletedDate";
            dtpCompletedDate.Size = new Size(228, 27);
            dtpCompletedDate.TabIndex = 13;
            // 
            // lblCompletedDate
            // 
            lblCompletedDate.AutoSize = true;
            lblCompletedDate.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCompletedDate.Location = new Point(17, 233);
            lblCompletedDate.Name = "lblCompletedDate";
            lblCompletedDate.Size = new Size(122, 20);
            lblCompletedDate.TabIndex = 12;
            lblCompletedDate.Text = "Completed Date:";
            // 
            // txtTotalCost
            // 
            txtTotalCost.BackColor = Color.LightGray;
            txtTotalCost.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTotalCost.Location = new Point(720, 176);
            txtTotalCost.Margin = new Padding(3, 4, 3, 4);
            txtTotalCost.Name = "txtTotalCost";
            txtTotalCost.ReadOnly = true;
            txtTotalCost.Size = new Size(137, 27);
            txtTotalCost.TabIndex = 11;
            txtTotalCost.Text = "0.00";
            txtTotalCost.TextAlign = HorizontalAlignment.Right;
            // 
            // lblTotalCost
            // 
            lblTotalCost.AutoSize = true;
            lblTotalCost.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalCost.ForeColor = Color.DarkGreen;
            lblTotalCost.Location = new Point(594, 180);
            lblTotalCost.Name = "lblTotalCost";
            lblTotalCost.Size = new Size(108, 20);
            lblTotalCost.TabIndex = 10;
            lblTotalCost.Text = "Total Cost (€):";
            // 
            // numLaborRate
            // 
            numLaborRate.DecimalPlaces = 2;
            numLaborRate.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numLaborRate.Location = new Point(434, 176);
            numLaborRate.Margin = new Padding(3, 4, 3, 4);
            numLaborRate.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numLaborRate.Name = "numLaborRate";
            numLaborRate.Size = new Size(137, 27);
            numLaborRate.TabIndex = 9;
            numLaborRate.Value = new decimal(new int[] { 25, 0, 0, 0 });
            // 
            // lblLaborRate
            // 
            lblLaborRate.AutoSize = true;
            lblLaborRate.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLaborRate.Location = new Point(274, 180);
            lblLaborRate.Name = "lblLaborRate";
            lblLaborRate.Size = new Size(125, 20);
            lblLaborRate.TabIndex = 8;
            lblLaborRate.Text = "Labor Rate (€/hr):";
            // 
            // numLaborHours
            // 
            numLaborHours.DecimalPlaces = 2;
            numLaborHours.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numLaborHours.Location = new Point(137, 176);
            numLaborHours.Margin = new Padding(3, 4, 3, 4);
            numLaborHours.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numLaborHours.Name = "numLaborHours";
            numLaborHours.Size = new Size(114, 27);
            numLaborHours.TabIndex = 7;
            // 
            // lblLaborHours
            // 
            lblLaborHours.AutoSize = true;
            lblLaborHours.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLaborHours.Location = new Point(17, 180);
            lblLaborHours.Name = "lblLaborHours";
            lblLaborHours.Size = new Size(93, 20);
            lblLaborHours.TabIndex = 6;
            lblLaborHours.Text = "Labor Hours:";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDescription.Location = new Point(137, 83);
            txtDescription.Margin = new Padding(3, 4, 3, 4);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(685, 79);
            txtDescription.TabIndex = 5;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescription.Location = new Point(17, 87);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(88, 20);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Description:";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(469, 36);
            cmbStatus.Margin = new Padding(3, 4, 3, 4);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(205, 28);
            cmbStatus.TabIndex = 3;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.Location = new Point(400, 40);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(52, 20);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Status:";
            // 
            // dtpServiceDate
            // 
            dtpServiceDate.Font = new Font("Segoe UI", 9F);
            dtpServiceDate.Format = DateTimePickerFormat.Short;
            dtpServiceDate.Location = new Point(137, 36);
            dtpServiceDate.Margin = new Padding(3, 4, 3, 4);
            dtpServiceDate.Name = "dtpServiceDate";
            dtpServiceDate.Size = new Size(228, 27);
            dtpServiceDate.TabIndex = 1;
            // 
            // lblServiceDate
            // 
            lblServiceDate.AutoSize = true;
            lblServiceDate.Font = new Font("Segoe UI", 9F);
            lblServiceDate.Location = new Point(17, 40);
            lblServiceDate.Name = "lblServiceDate";
            lblServiceDate.Size = new Size(95, 20);
            lblServiceDate.TabIndex = 0;
            lblServiceDate.Text = "Service Date:";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // btnViewInvoice
            // 
            btnViewInvoice.BackColor = Color.FromArgb(0, 150, 136);
            btnViewInvoice.FlatAppearance.BorderColor = Color.Black;
            btnViewInvoice.FlatStyle = FlatStyle.Flat;
            btnViewInvoice.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewInvoice.ForeColor = Color.White;
            btnViewInvoice.Location = new Point(400, 73);
            btnViewInvoice.Margin = new Padding(3, 4, 3, 4);
            btnViewInvoice.Name = "btnViewInvoice";
            btnViewInvoice.Size = new Size(137, 40);
            btnViewInvoice.TabIndex = 11;
            btnViewInvoice.Text = "📄 View Invoice";
            btnViewInvoice.UseVisualStyleBackColor = false;
            btnViewInvoice.Click += btnViewInvoice_Click;
            // 
            // btnExportCsv
            // 
            btnExportCsv.BackColor = Color.FromArgb(52, 152, 219);
            btnExportCsv.FlatAppearance.BorderColor = Color.Black;
            btnExportCsv.FlatStyle = FlatStyle.Flat;
            btnExportCsv.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExportCsv.ForeColor = Color.White;
            btnExportCsv.Location = new Point(549, 69);
            btnExportCsv.Margin = new Padding(3, 4, 3, 4);
            btnExportCsv.Name = "btnExportCsv";
            btnExportCsv.Size = new Size(149, 47);
            btnExportCsv.TabIndex = 12;
            btnExportCsv.Text = "📊 Export to CSV";
            btnExportCsv.UseVisualStyleBackColor = false;
            btnExportCsv.Click += btnExportCsv_Click;
            // 
            // ServiceOrdersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1353, 881);
            Controls.Add(btnExportCsv);
            Controls.Add(btnViewInvoice);
            Controls.Add(groupBoxDetails);
            Controls.Add(btnRefresh);
            Controls.Add(btnShowAll);
            Controls.Add(btnSearch);
            Controls.Add(cmbStatusFilter);
            Controls.Add(statusFilter);
            Controls.Add(dataGridViewOrders);
            Controls.Add(cmbVehicles);
            Controls.Add(lblVehicle);
            Controls.Add(cmbCustomers);
            Controls.Add(lblCustomer);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ServiceOrdersForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Service Orders";
            Load += ServiceOrdersForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).EndInit();
            groupBoxDetails.ResumeLayout(false);
            groupBoxDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numLaborRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)numLaborHours).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCustomer;
        private ComboBox cmbCustomers;
        private Label lblVehicle;
        private ComboBox cmbVehicles;
        private DataGridView dataGridViewOrders;
        private Label statusFilter;
        private ComboBox cmbStatusFilter;
        private Button btnSearch;
        private Button btnShowAll;
        private Button btnRefresh;
        private GroupBox groupBoxDetails;
        private DateTimePicker dtpServiceDate;
        private Label lblServiceDate;
        private ComboBox cmbStatus;
        private Label lblStatus;
        private TextBox txtDescription;
        private Label lblDescription;
        private NumericUpDown numLaborHours;
        private Label lblLaborHours;
        private NumericUpDown numLaborRate;
        private Label lblLaborRate;
        private Label lblTotalCost;
        private TextBox txtTotalCost;
        private Label lblCompletedDate;
        private DateTimePicker dtpCompletedDate;
        private CheckBox chkMarkCompleted;
        private Label lblNotes;
        private TextBox txtNotes;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private ErrorProvider errorProvider1;
        private Button btnViewInvoice;
        private Button btnExportCsv;
    }
}