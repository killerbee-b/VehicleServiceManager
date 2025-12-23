namespace VehicleServiceManager.Forms
{
    partial class VehicleManagment
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
            lblCustomer = new Label();
            cmbCustomer = new ComboBox();
            lblSearch = new Label();
            txtSearch = new TextBox();
            txtVIN = new TextBox();
            txtModel = new TextBox();
            txtMake = new TextBox();
            numYear = new NumericUpDown();
            txtLicensePlate = new TextBox();
            numMileage = new NumericUpDown();
            btnSearch = new Button();
            lblMake = new Label();
            lblVIN = new Label();
            lblLicensePlate = new Label();
            lblModel = new Label();
            lblYear = new Label();
            lblMileage = new Label();
            dataVehicles = new DataGridView();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)numYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMileage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataVehicles).BeginInit();
            SuspendLayout();
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCustomer.Location = new Point(29, 18);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(87, 23);
            lblCustomer.TabIndex = 0;
            lblCustomer.Text = "Customer";
            // 
            // cmbCustomer
            // 
            cmbCustomer.FormattingEnabled = true;
            cmbCustomer.Location = new Point(120, 15);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.Size = new Size(251, 28);
            cmbCustomer.TabIndex = 1;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSearch.Location = new Point(42, 73);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(63, 23);
            lblSearch.TabIndex = 2;
            lblSearch.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(120, 73);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(171, 27);
            txtSearch.TabIndex = 3;
            // 
            // txtVIN
            // 
            txtVIN.Location = new Point(169, 151);
            txtVIN.Name = "txtVIN";
            txtVIN.Size = new Size(147, 27);
            txtVIN.TabIndex = 5;
            // 
            // txtModel
            // 
            txtModel.Location = new Point(169, 236);
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(147, 27);
            txtModel.TabIndex = 7;
            // 
            // txtMake
            // 
            txtMake.Location = new Point(169, 196);
            txtMake.Name = "txtMake";
            txtMake.Size = new Size(147, 27);
            txtMake.TabIndex = 8;
            // 
            // numYear
            // 
            numYear.Location = new Point(166, 323);
            numYear.Maximum = new decimal(new int[] { 2026, 0, 0, 0 });
            numYear.Minimum = new decimal(new int[] { 1980, 0, 0, 0 });
            numYear.Name = "numYear";
            numYear.Size = new Size(150, 27);
            numYear.TabIndex = 9;
            numYear.Value = new decimal(new int[] { 1980, 0, 0, 0 });
            // 
            // txtLicensePlate
            // 
            txtLicensePlate.Location = new Point(169, 279);
            txtLicensePlate.Name = "txtLicensePlate";
            txtLicensePlate.Size = new Size(147, 27);
            txtLicensePlate.TabIndex = 10;
            // 
            // numMileage
            // 
            numMileage.Location = new Point(166, 369);
            numMileage.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numMileage.Name = "numMileage";
            numMileage.Size = new Size(150, 27);
            numMileage.TabIndex = 11;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.LightSteelBlue;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.Location = new Point(307, 73);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(68, 28);
            btnSearch.TabIndex = 25;
            btnSearch.Text = "🔍 Filter";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // lblMake
            // 
            lblMake.AutoSize = true;
            lblMake.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMake.Location = new Point(29, 196);
            lblMake.Name = "lblMake";
            lblMake.Size = new Size(54, 23);
            lblMake.TabIndex = 27;
            lblMake.Text = "Make";
            // 
            // lblVIN
            // 
            lblVIN.AutoSize = true;
            lblVIN.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblVIN.Location = new Point(29, 151);
            lblVIN.Name = "lblVIN";
            lblVIN.Size = new Size(39, 23);
            lblVIN.TabIndex = 26;
            lblVIN.Text = "VIN";
            // 
            // lblLicensePlate
            // 
            lblLicensePlate.AutoSize = true;
            lblLicensePlate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLicensePlate.Location = new Point(29, 283);
            lblLicensePlate.Name = "lblLicensePlate";
            lblLicensePlate.Size = new Size(112, 23);
            lblLicensePlate.TabIndex = 29;
            lblLicensePlate.Text = "License Plate";
            // 
            // lblModel
            // 
            lblModel.AutoSize = true;
            lblModel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblModel.Location = new Point(29, 237);
            lblModel.Name = "lblModel";
            lblModel.Size = new Size(61, 23);
            lblModel.TabIndex = 28;
            lblModel.Text = "Model";
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblYear.Location = new Point(29, 327);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(43, 23);
            lblYear.TabIndex = 30;
            lblYear.Text = "Year";
            // 
            // lblMileage
            // 
            lblMileage.AutoSize = true;
            lblMileage.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMileage.Location = new Point(29, 373);
            lblMileage.Name = "lblMileage";
            lblMileage.Size = new Size(74, 23);
            lblMileage.TabIndex = 31;
            lblMileage.Text = "Mileage";
            lblMileage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataVehicles
            // 
            dataVehicles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataVehicles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataVehicles.Location = new Point(381, 15);
            dataVehicles.Name = "dataVehicles";
            dataVehicles.RowHeadersWidth = 51;
            dataVehicles.Size = new Size(839, 525);
            dataVehicles.TabIndex = 39;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.LightGray;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Location = new Point(188, 488);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(128, 52);
            btnClear.TabIndex = 38;
            btnClear.Text = "🔄 Clear";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.LightCoral;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(188, 414);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(128, 52);
            btnDelete.TabIndex = 37;
            btnDelete.Text = "🗑️ Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.DeepSkyBlue;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Location = new Point(48, 488);
            btnUpdate.Margin = new Padding(3, 4, 3, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(128, 52);
            btnUpdate.TabIndex = 36;
            btnUpdate.Text = "📝 Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.LightGreen;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Location = new Point(48, 414);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(128, 52);
            btnAdd.TabIndex = 35;
            btnAdd.Text = "➕ Add New";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // VehicleManagment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1232, 553);
            Controls.Add(dataVehicles);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(lblMileage);
            Controls.Add(lblYear);
            Controls.Add(lblLicensePlate);
            Controls.Add(lblModel);
            Controls.Add(lblMake);
            Controls.Add(lblVIN);
            Controls.Add(btnSearch);
            Controls.Add(numMileage);
            Controls.Add(txtLicensePlate);
            Controls.Add(numYear);
            Controls.Add(txtMake);
            Controls.Add(txtModel);
            Controls.Add(txtVIN);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(cmbCustomer);
            Controls.Add(lblCustomer);
            Name = "VehicleManagment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Vehicle Managment";
            ((System.ComponentModel.ISupportInitialize)numYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMileage).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataVehicles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCustomer;
        private ComboBox cmbCustomer;
        private Label lblSearch;
        private TextBox txtSearch;
        private TextBox txtVIN;
        private TextBox txtModel;
        private TextBox txtMake;
        private NumericUpDown numYear;
        private TextBox txtLicensePlate;
        private NumericUpDown numMileage;
        private Button btnSearch;
        private Label lblMake;
        private Label lblVIN;
        private Label lblLicensePlate;
        private Label lblModel;
        private Label lblYear;
        private Label lblMileage;
        private DataGridView dataVehicles;
        private Button btnClear;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
    }
}