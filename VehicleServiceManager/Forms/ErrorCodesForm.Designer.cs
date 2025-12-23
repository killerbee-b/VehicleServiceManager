namespace VehicleServiceManager.Forms
{
    partial class ErrorCodesForm
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
            lblSearch = new Label();
            btnFilter = new Button();
            txtSearch = new TextBox();
            lblModule = new Label();
            cmbVehicle = new ComboBox();
            cmbModule = new ComboBox();
            lblVehicle = new Label();
            btnClearFilter = new Button();
            grpBoxCodeDetails = new GroupBox();
            label5 = new Label();
            lblSymptoms = new Label();
            lblSeverity = new Label();
            labelModel = new Label();
            lblTitle = new Label();
            lblDTCCode = new Label();
            txtFixGuide = new TextBox();
            txtSymptoms = new TextBox();
            cmbSeverity = new ComboBox();
            cmbDetailModule = new ComboBox();
            txtTitle = new TextBox();
            txtCode = new TextBox();
            btnReset = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            dataErrorCodes = new DataGridView();
            btnImportCsv = new Button();
            btnExportCsv = new Button();
            btnExportJson = new Button();
            btnImportJson = new Button();
            grpBoxCodeDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataErrorCodes).BeginInit();
            SuspendLayout();
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSearch.Location = new Point(12, 36);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(63, 23);
            lblSearch.TabIndex = 31;
            lblSearch.Text = "Search";
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.LightSteelBlue;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnFilter.Location = new Point(274, 34);
            btnFilter.Margin = new Padding(3, 4, 3, 4);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(68, 28);
            btnFilter.TabIndex = 30;
            btnFilter.Text = "🔍 Filter";
            btnFilter.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(92, 34);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(171, 27);
            txtSearch.TabIndex = 29;
            // 
            // lblModule
            // 
            lblModule.AutoSize = true;
            lblModule.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblModule.Location = new Point(435, 37);
            lblModule.Name = "lblModule";
            lblModule.Size = new Size(76, 23);
            lblModule.TabIndex = 32;
            lblModule.Text = "Module:";
            // 
            // cmbVehicle
            // 
            cmbVehicle.FormattingEnabled = true;
            cmbVehicle.Location = new Point(762, 34);
            cmbVehicle.Name = "cmbVehicle";
            cmbVehicle.Size = new Size(151, 28);
            cmbVehicle.TabIndex = 33;
            // 
            // cmbModule
            // 
            cmbModule.FormattingEnabled = true;
            cmbModule.Location = new Point(517, 34);
            cmbModule.Name = "cmbModule";
            cmbModule.Size = new Size(151, 28);
            cmbModule.TabIndex = 34;
            // 
            // lblVehicle
            // 
            lblVehicle.AutoSize = true;
            lblVehicle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblVehicle.Location = new Point(683, 37);
            lblVehicle.Name = "lblVehicle";
            lblVehicle.Size = new Size(71, 23);
            lblVehicle.TabIndex = 35;
            lblVehicle.Text = "Vehicle:";
            // 
            // btnClearFilter
            // 
            btnClearFilter.Location = new Point(348, 34);
            btnClearFilter.Margin = new Padding(3, 4, 3, 4);
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.Size = new Size(69, 28);
            btnClearFilter.TabIndex = 36;
            btnClearFilter.Text = "🔄 Refresh";
            btnClearFilter.UseVisualStyleBackColor = true;
            // 
            // grpBoxCodeDetails
            // 
            grpBoxCodeDetails.BackColor = Color.DarkSlateGray;
            grpBoxCodeDetails.Controls.Add(label5);
            grpBoxCodeDetails.Controls.Add(lblSymptoms);
            grpBoxCodeDetails.Controls.Add(lblSeverity);
            grpBoxCodeDetails.Controls.Add(labelModel);
            grpBoxCodeDetails.Controls.Add(lblTitle);
            grpBoxCodeDetails.Controls.Add(lblDTCCode);
            grpBoxCodeDetails.Controls.Add(txtFixGuide);
            grpBoxCodeDetails.Controls.Add(txtSymptoms);
            grpBoxCodeDetails.Controls.Add(cmbSeverity);
            grpBoxCodeDetails.Controls.Add(cmbDetailModule);
            grpBoxCodeDetails.Controls.Add(txtTitle);
            grpBoxCodeDetails.Controls.Add(txtCode);
            grpBoxCodeDetails.Location = new Point(13, 120);
            grpBoxCodeDetails.Name = "grpBoxCodeDetails";
            grpBoxCodeDetails.Size = new Size(389, 468);
            grpBoxCodeDetails.TabIndex = 37;
            grpBoxCodeDetails.TabStop = false;
            grpBoxCodeDetails.Text = "Code Details";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.Location = new Point(17, 372);
            label5.Name = "label5";
            label5.Size = new Size(62, 23);
            label5.TabIndex = 44;
            label5.Text = "Guide:";
            // 
            // lblSymptoms
            // 
            lblSymptoms.AutoSize = true;
            lblSymptoms.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSymptoms.Location = new Point(17, 292);
            lblSymptoms.Name = "lblSymptoms";
            lblSymptoms.Size = new Size(101, 23);
            lblSymptoms.TabIndex = 43;
            lblSymptoms.Text = "Symptoms:";
            // 
            // lblSeverity
            // 
            lblSeverity.AutoSize = true;
            lblSeverity.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSeverity.Location = new Point(17, 229);
            lblSeverity.Name = "lblSeverity";
            lblSeverity.Size = new Size(80, 23);
            lblSeverity.TabIndex = 42;
            lblSeverity.Text = "Severity:";
            // 
            // labelModel
            // 
            labelModel.AutoSize = true;
            labelModel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelModel.Location = new Point(17, 179);
            labelModel.Name = "labelModel";
            labelModel.Size = new Size(76, 23);
            labelModel.TabIndex = 41;
            labelModel.Text = "Module:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTitle.Location = new Point(17, 125);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(51, 23);
            lblTitle.TabIndex = 40;
            lblTitle.Text = "Title:";
            // 
            // lblDTCCode
            // 
            lblDTCCode.AutoSize = true;
            lblDTCCode.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDTCCode.Location = new Point(17, 68);
            lblDTCCode.Name = "lblDTCCode";
            lblDTCCode.Size = new Size(93, 23);
            lblDTCCode.TabIndex = 39;
            lblDTCCode.Text = "DTC Code:";
            // 
            // txtFixGuide
            // 
            txtFixGuide.Location = new Point(153, 346);
            txtFixGuide.Multiline = true;
            txtFixGuide.Name = "txtFixGuide";
            txtFixGuide.ScrollBars = ScrollBars.Vertical;
            txtFixGuide.Size = new Size(192, 69);
            txtFixGuide.TabIndex = 5;
            // 
            // txtSymptoms
            // 
            txtSymptoms.Location = new Point(153, 282);
            txtSymptoms.Multiline = true;
            txtSymptoms.Name = "txtSymptoms";
            txtSymptoms.ScrollBars = ScrollBars.Vertical;
            txtSymptoms.Size = new Size(192, 46);
            txtSymptoms.TabIndex = 4;
            // 
            // cmbSeverity
            // 
            cmbSeverity.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSeverity.FormattingEnabled = true;
            cmbSeverity.Location = new Point(153, 224);
            cmbSeverity.Name = "cmbSeverity";
            cmbSeverity.Size = new Size(192, 28);
            cmbSeverity.TabIndex = 3;
            // 
            // cmbDetailModule
            // 
            cmbDetailModule.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDetailModule.FormattingEnabled = true;
            cmbDetailModule.Location = new Point(153, 174);
            cmbDetailModule.Name = "cmbDetailModule";
            cmbDetailModule.Size = new Size(192, 28);
            cmbDetailModule.TabIndex = 2;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(153, 114);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(192, 27);
            txtTitle.TabIndex = 1;
            // 
            // txtCode
            // 
            txtCode.Location = new Point(153, 64);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(192, 27);
            txtCode.TabIndex = 0;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.LightGray;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Location = new Point(306, 608);
            btnReset.Margin = new Padding(3, 4, 3, 4);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(91, 60);
            btnReset.TabIndex = 41;
            btnReset.Text = "🔄 Clear";
            btnReset.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.LightCoral;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(112, 608);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(91, 60);
            btnDelete.TabIndex = 40;
            btnDelete.Text = "🗑️ Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.DeepSkyBlue;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Location = new Point(209, 608);
            btnUpdate.Margin = new Padding(3, 4, 3, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(91, 60);
            btnUpdate.TabIndex = 39;
            btnUpdate.Text = "📝 Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.LightGreen;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Location = new Point(15, 608);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(91, 60);
            btnAdd.TabIndex = 38;
            btnAdd.Text = "➕ Add New";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // dataErrorCodes
            // 
            dataErrorCodes.AllowUserToAddRows = false;
            dataErrorCodes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataErrorCodes.Location = new Point(435, 120);
            dataErrorCodes.MultiSelect = false;
            dataErrorCodes.Name = "dataErrorCodes";
            dataErrorCodes.ReadOnly = true;
            dataErrorCodes.RowHeadersWidth = 51;
            dataErrorCodes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataErrorCodes.Size = new Size(565, 468);
            dataErrorCodes.TabIndex = 42;
            // 
            // btnImportCsv
            // 
            btnImportCsv.BackColor = Color.LightSteelBlue;
            btnImportCsv.FlatStyle = FlatStyle.Flat;
            btnImportCsv.Location = new Point(508, 608);
            btnImportCsv.Margin = new Padding(3, 4, 3, 4);
            btnImportCsv.Name = "btnImportCsv";
            btnImportCsv.Size = new Size(91, 60);
            btnImportCsv.TabIndex = 43;
            btnImportCsv.Text = "⬆ Import CSV";
            btnImportCsv.UseVisualStyleBackColor = false;
            btnImportCsv.Click += button1_Click;
            // 
            // btnExportCsv
            // 
            btnExportCsv.BackColor = Color.Gainsboro;
            btnExportCsv.FlatStyle = FlatStyle.Flat;
            btnExportCsv.Location = new Point(617, 608);
            btnExportCsv.Margin = new Padding(3, 4, 3, 4);
            btnExportCsv.Name = "btnExportCsv";
            btnExportCsv.Size = new Size(91, 60);
            btnExportCsv.TabIndex = 44;
            btnExportCsv.Text = "⬇ Export CSV";
            btnExportCsv.UseVisualStyleBackColor = false;
            // 
            // btnExportJson
            // 
            btnExportJson.BackColor = Color.Gainsboro;
            btnExportJson.FlatStyle = FlatStyle.Flat;
            btnExportJson.Location = new Point(841, 608);
            btnExportJson.Margin = new Padding(3, 4, 3, 4);
            btnExportJson.Name = "btnExportJson";
            btnExportJson.Size = new Size(91, 60);
            btnExportJson.TabIndex = 46;
            btnExportJson.Text = "⬇ Export JSON";
            btnExportJson.UseVisualStyleBackColor = false;
            // 
            // btnImportJson
            // 
            btnImportJson.BackColor = Color.LightSteelBlue;
            btnImportJson.FlatStyle = FlatStyle.Flat;
            btnImportJson.Location = new Point(732, 608);
            btnImportJson.Margin = new Padding(3, 4, 3, 4);
            btnImportJson.Name = "btnImportJson";
            btnImportJson.Size = new Size(91, 60);
            btnImportJson.TabIndex = 45;
            btnImportJson.Text = "⬆ Import JSON";
            btnImportJson.UseVisualStyleBackColor = false;
            // 
            // ErrorCodesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 729);
            Controls.Add(btnExportJson);
            Controls.Add(btnImportJson);
            Controls.Add(btnExportCsv);
            Controls.Add(btnImportCsv);
            Controls.Add(dataErrorCodes);
            Controls.Add(btnReset);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(grpBoxCodeDetails);
            Controls.Add(btnClearFilter);
            Controls.Add(lblVehicle);
            Controls.Add(cmbModule);
            Controls.Add(cmbVehicle);
            Controls.Add(lblModule);
            Controls.Add(lblSearch);
            Controls.Add(btnFilter);
            Controls.Add(txtSearch);
            Name = "ErrorCodesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ErrorCodesForm";
            Load += ErrorCodesForm_Load;
            grpBoxCodeDetails.ResumeLayout(false);
            grpBoxCodeDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataErrorCodes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSearch;
        private Button btnFilter;
        private TextBox txtSearch;
        private Label lblModule;
        private ComboBox cmbVehicle;
        private ComboBox cmbModule;
        private Label lblVehicle;
        private Button btnClearFilter;
        private GroupBox grpBoxCodeDetails;
        private TextBox txtTitle;
        private TextBox txtCode;
        private ComboBox cmbSeverity;
        private ComboBox cmbDetailModule;
        private TextBox txtFixGuide;
        private TextBox txtSymptoms;
        private Button btnReset;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private DataGridView dataErrorCodes;
        private Label label5;
        private Label lblSymptoms;
        private Label lblSeverity;
        private Label labelModel;
        private Label lblTitle;
        private Label lblDTCCode;
        private Button btnImportCsv;
        private Button btnExportCsv;
        private Button btnExportJson;
        private Button btnImportJson;
    }
}