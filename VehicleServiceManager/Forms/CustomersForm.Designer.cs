namespace VehicleServiceManager.Forms
{
    partial class CustomersForm
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
            errorProvider1 = new ErrorProvider(components);
            btnDelete = new Button();
            btnClear = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            txtAddress = new TextBox();
            dataGridViewCustomers = new DataGridView();
            btnRefresh = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblAddress = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            lblPhone = new Label();
            txtPhone = new TextBox();
            txtLastName = new TextBox();
            lblLastName = new Label();
            txtFirstName = new TextBox();
            lblFirstName = new Label();
            groupBoxDetails = new GroupBox();
            labelSearch = new Label();
            btnExportCsv = new Button();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCustomers).BeginInit();
            groupBoxDetails.SuspendLayout();
            SuspendLayout();
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(340, 150);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 35);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "🗑️ Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(450, 150);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 35);
            btnClear.TabIndex = 13;
            btnClear.Text = "🔄 Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(230, 150);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 35);
            btnUpdate.TabIndex = 11;
            btnUpdate.Text = "✏️ Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(120, 150);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 35);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "➕ Add New";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(470, 62);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(250, 60);
            txtAddress.TabIndex = 9;
            // 
            // dataGridViewCustomers
            // 
            dataGridViewCustomers.AllowUserToAddRows = false;
            dataGridViewCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCustomers.Location = new Point(17, 73);
            dataGridViewCustomers.MultiSelect = false;
            dataGridViewCustomers.Name = "dataGridViewCustomers";
            dataGridViewCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCustomers.Size = new Size(950, 250);
            dataGridViewCustomers.TabIndex = 10;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(397, 28);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 28);
            btnRefresh.TabIndex = 9;
            btnRefresh.Text = "🔄 Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(287, 28);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 28);
            btnSearch.TabIndex = 8;
            btnSearch.Text = "🔍 Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(77, 30);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 23);
            txtSearch.TabIndex = 7;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(400, 65);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(52, 15);
            lblAddress.TabIndex = 8;
            lblAddress.Text = "Address:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(470, 27);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(250, 23);
            txtEmail.TabIndex = 7;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(400, 30);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email:";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(15, 100);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(44, 15);
            lblPhone.TabIndex = 5;
            lblPhone.Text = "Phone:";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(120, 97);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(200, 23);
            txtPhone.TabIndex = 4;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(120, 62);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(200, 23);
            txtLastName.TabIndex = 3;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(15, 65);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(66, 15);
            lblLastName.TabIndex = 2;
            lblLastName.Text = "Last Name:";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(120, 27);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(200, 23);
            txtFirstName.TabIndex = 1;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(15, 30);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(67, 15);
            lblFirstName.TabIndex = 0;
            lblFirstName.Text = "First Name:";
            // 
            // groupBoxDetails
            // 
            groupBoxDetails.Controls.Add(btnDelete);
            groupBoxDetails.Controls.Add(btnClear);
            groupBoxDetails.Controls.Add(btnUpdate);
            groupBoxDetails.Controls.Add(btnAdd);
            groupBoxDetails.Controls.Add(txtAddress);
            groupBoxDetails.Controls.Add(lblAddress);
            groupBoxDetails.Controls.Add(txtEmail);
            groupBoxDetails.Controls.Add(lblEmail);
            groupBoxDetails.Controls.Add(lblPhone);
            groupBoxDetails.Controls.Add(txtPhone);
            groupBoxDetails.Controls.Add(txtLastName);
            groupBoxDetails.Controls.Add(lblLastName);
            groupBoxDetails.Controls.Add(txtFirstName);
            groupBoxDetails.Controls.Add(lblFirstName);
            groupBoxDetails.Location = new Point(17, 333);
            groupBoxDetails.Name = "groupBoxDetails";
            groupBoxDetails.Size = new Size(950, 200);
            groupBoxDetails.TabIndex = 11;
            groupBoxDetails.TabStop = false;
            groupBoxDetails.Text = "Customer Details";
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.Font = new Font("Segoe UI", 10F);
            labelSearch.Location = new Point(17, 33);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(49, 19);
            labelSearch.TabIndex = 6;
            labelSearch.Text = "Search";
            // 
            // btnExportCsv
            // 
            btnExportCsv.BackColor = Color.FromArgb(52, 152, 219);
            btnExportCsv.Cursor = Cursors.Hand;
            btnExportCsv.FlatAppearance.BorderSize = 0;
            btnExportCsv.FlatStyle = FlatStyle.Flat;
            btnExportCsv.ForeColor = Color.White;
            btnExportCsv.Location = new Point(507, 25);
            btnExportCsv.Name = "btnExportCsv";
            btnExportCsv.Size = new Size(130, 35);
            btnExportCsv.TabIndex = 12;
            btnExportCsv.Text = "📊 Export to CSV";
            btnExportCsv.UseVisualStyleBackColor = false;
            btnExportCsv.Click += btnExportCsv_Click;
            // 
            // CustomersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(btnExportCsv);
            Controls.Add(dataGridViewCustomers);
            Controls.Add(btnRefresh);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(groupBoxDetails);
            Controls.Add(labelSearch);
            Name = "CustomersForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Customer Management";
            Load += CustomersForm_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCustomers).EndInit();
            groupBoxDetails.ResumeLayout(false);
            groupBoxDetails.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ErrorProvider errorProvider1;
        private DataGridView dataGridViewCustomers;
        private Button btnRefresh;
        private Button btnSearch;
        private TextBox txtSearch;
        private GroupBox groupBoxDetails;
        private Button btnDelete;
        private Button btnClear;
        private Button btnUpdate;
        private Button btnAdd;
        private TextBox txtAddress;
        private Label lblAddress;
        private TextBox txtEmail;
        private Label lblEmail;
        private Label lblPhone;
        private TextBox txtPhone;
        private TextBox txtLastName;
        private Label lblLastName;
        private TextBox txtFirstName;
        private Label lblFirstName;
        private Label labelSearch;
        private Button btnExportCsv;
    }
}