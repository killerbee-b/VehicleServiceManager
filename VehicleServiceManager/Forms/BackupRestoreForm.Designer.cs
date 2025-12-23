namespace VehicleServiceManager.Forms
{
    partial class BackupRestoreForm
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
            groupBoxStats = new GroupBox();
            btnRefreshStats = new Button();
            lblPartsCount = new Label();
            lblServiceOrdersCount = new Label();
            lblVehiclesCount = new Label();
            lblCustomersCount = new Label();
            groupBoxBackup = new GroupBox();
            btnBackup = new Button();
            lblBackupInfo = new Label();
            groupBoxRestore = new GroupBox();
            btnRestore = new Button();
            lblRestoreInfo = new Label();
            groupBoxDanger = new GroupBox();
            btnClearDatabase = new Button();
            btnClose = new Button();
            panelHeader.SuspendLayout();
            groupBoxStats.SuspendLayout();
            groupBoxBackup.SuspendLayout();
            groupBoxRestore.SuspendLayout();
            groupBoxDanger.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(41, 128, 185);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(884, 80);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(413, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🔄 DATABASE BACKUP && RESTORE";
            // 
            // groupBoxStats
            // 
            groupBoxStats.Controls.Add(btnRefreshStats);
            groupBoxStats.Controls.Add(lblPartsCount);
            groupBoxStats.Controls.Add(lblServiceOrdersCount);
            groupBoxStats.Controls.Add(lblVehiclesCount);
            groupBoxStats.Controls.Add(lblCustomersCount);
            groupBoxStats.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxStats.ForeColor = Color.FromArgb(52, 73, 94);
            groupBoxStats.Location = new Point(30, 110);
            groupBoxStats.Name = "groupBoxStats";
            groupBoxStats.Size = new Size(840, 140);
            groupBoxStats.TabIndex = 1;
            groupBoxStats.TabStop = false;
            groupBoxStats.Text = "Current Database Statistics";
            // 
            // btnRefreshStats
            // 
            btnRefreshStats.BackColor = Color.FromArgb(149, 165, 166);
            btnRefreshStats.Cursor = Cursors.Hand;
            btnRefreshStats.FlatStyle = FlatStyle.Flat;
            btnRefreshStats.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRefreshStats.ForeColor = Color.White;
            btnRefreshStats.Location = new Point(700, 40);
            btnRefreshStats.Name = "btnRefreshStats";
            btnRefreshStats.Size = new Size(120, 35);
            btnRefreshStats.TabIndex = 4;
            btnRefreshStats.Text = "🔄 Refresh";
            btnRefreshStats.UseVisualStyleBackColor = false;
            btnRefreshStats.Click += btnRefreshStats_Click;
            // 
            // lblPartsCount
            // 
            lblPartsCount.AutoSize = true;
            lblPartsCount.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPartsCount.ForeColor = Color.FromArgb(155, 89, 182);
            lblPartsCount.Location = new Point(40, 80);
            lblPartsCount.Name = "lblPartsCount";
            lblPartsCount.Size = new Size(92, 21);
            lblPartsCount.TabIndex = 3;
            lblPartsCount.Text = "📦 Parts: 0";
            // 
            // lblServiceOrdersCount
            // 
            lblServiceOrdersCount.AutoSize = true;
            lblServiceOrdersCount.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblServiceOrdersCount.ForeColor = Color.FromArgb(230, 126, 34);
            lblServiceOrdersCount.Location = new Point(450, 40);
            lblServiceOrdersCount.Name = "lblServiceOrdersCount";
            lblServiceOrdersCount.Size = new Size(164, 21);
            lblServiceOrdersCount.TabIndex = 2;
            lblServiceOrdersCount.Text = "🔧 Service Orders: 0";
            // 
            // lblVehiclesCount
            // 
            lblVehiclesCount.AutoSize = true;
            lblVehiclesCount.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVehiclesCount.ForeColor = Color.FromArgb(52, 152, 219);
            lblVehiclesCount.Location = new Point(250, 40);
            lblVehiclesCount.Name = "lblVehiclesCount";
            lblVehiclesCount.Size = new Size(117, 21);
            lblVehiclesCount.TabIndex = 1;
            lblVehiclesCount.Text = "🚗 Vehicles: 0";
            // 
            // lblCustomersCount
            // 
            lblCustomersCount.AutoSize = true;
            lblCustomersCount.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCustomersCount.ForeColor = Color.FromArgb(46, 204, 113);
            lblCustomersCount.Location = new Point(40, 40);
            lblCustomersCount.Name = "lblCustomersCount";
            lblCustomersCount.Size = new Size(134, 21);
            lblCustomersCount.TabIndex = 0;
            lblCustomersCount.Text = "👥 Customers: 0";
            // 
            // groupBoxBackup
            // 
            groupBoxBackup.Controls.Add(btnBackup);
            groupBoxBackup.Controls.Add(lblBackupInfo);
            groupBoxBackup.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxBackup.ForeColor = Color.FromArgb(52, 73, 94);
            groupBoxBackup.Location = new Point(30, 270);
            groupBoxBackup.Name = "groupBoxBackup";
            groupBoxBackup.Size = new Size(410, 220);
            groupBoxBackup.TabIndex = 2;
            groupBoxBackup.TabStop = false;
            groupBoxBackup.Text = "Backup Database";
            // 
            // btnBackup
            // 
            btnBackup.BackColor = Color.FromArgb(46, 204, 113);
            btnBackup.FlatStyle = FlatStyle.Flat;
            btnBackup.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBackup.ForeColor = Color.White;
            btnBackup.Location = new Point(20, 130);
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new Size(370, 50);
            btnBackup.TabIndex = 1;
            btnBackup.Text = "💾 CREATE BACKUP";
            btnBackup.UseVisualStyleBackColor = false;
            btnBackup.Click += btnBackup_Click;
            // 
            // lblBackupInfo
            // 
            lblBackupInfo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBackupInfo.ForeColor = Color.FromArgb(127, 140, 141);
            lblBackupInfo.Location = new Point(20, 35);
            lblBackupInfo.Name = "lblBackupInfo";
            lblBackupInfo.Size = new Size(370, 80);
            lblBackupInfo.TabIndex = 0;
            lblBackupInfo.Text = "Create a backup of all database records to a JSON file. This includes customers, vehicles, service orders, and parts inventory.";
            // 
            // groupBoxRestore
            // 
            groupBoxRestore.Controls.Add(btnRestore);
            groupBoxRestore.Controls.Add(lblRestoreInfo);
            groupBoxRestore.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxRestore.ForeColor = Color.FromArgb(52, 73, 94);
            groupBoxRestore.Location = new Point(460, 270);
            groupBoxRestore.Name = "groupBoxRestore";
            groupBoxRestore.Size = new Size(410, 220);
            groupBoxRestore.TabIndex = 3;
            groupBoxRestore.TabStop = false;
            groupBoxRestore.Text = "Restore Database";
            // 
            // btnRestore
            // 
            btnRestore.BackColor = Color.FromArgb(52, 152, 219);
            btnRestore.FlatStyle = FlatStyle.Flat;
            btnRestore.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRestore.ForeColor = Color.White;
            btnRestore.Location = new Point(20, 130);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(370, 50);
            btnRestore.TabIndex = 1;
            btnRestore.Text = "📥 RESTORE FROM BACKUP";
            btnRestore.UseVisualStyleBackColor = false;
            btnRestore.Click += btnRestore_Click;
            // 
            // lblRestoreInfo
            // 
            lblRestoreInfo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRestoreInfo.ForeColor = Color.FromArgb(127, 140, 141);
            lblRestoreInfo.Location = new Point(20, 35);
            lblRestoreInfo.Name = "lblRestoreInfo";
            lblRestoreInfo.Size = new Size(370, 80);
            lblRestoreInfo.TabIndex = 0;
            lblRestoreInfo.Text = "Restore database from a previously created backup file. WARNING: This will replace all current data!";
            // 
            // groupBoxDanger
            // 
            groupBoxDanger.Controls.Add(btnClearDatabase);
            groupBoxDanger.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxDanger.ForeColor = Color.FromArgb(231, 76, 60);
            groupBoxDanger.Location = new Point(30, 510);
            groupBoxDanger.Name = "groupBoxDanger";
            groupBoxDanger.Size = new Size(410, 90);
            groupBoxDanger.TabIndex = 4;
            groupBoxDanger.TabStop = false;
            groupBoxDanger.Text = "⚠️ DANGER ZONE";
            // 
            // btnClearDatabase
            // 
            btnClearDatabase.BackColor = Color.FromArgb(231, 76, 60);
            btnClearDatabase.FlatStyle = FlatStyle.Flat;
            btnClearDatabase.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClearDatabase.ForeColor = Color.White;
            btnClearDatabase.Location = new Point(20, 35);
            btnClearDatabase.Name = "btnClearDatabase";
            btnClearDatabase.Size = new Size(370, 40);
            btnClearDatabase.TabIndex = 0;
            btnClearDatabase.Text = "🗑️ CLEAR ALL DATA";
            btnClearDatabase.UseVisualStyleBackColor = false;
            btnClearDatabase.Click += btnClearDatabase_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(189, 195, 199);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(700, 560);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(170, 40);
            btnClose.TabIndex = 5;
            btnClose.Text = "✖ Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // BackupRestoreForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(884, 611);
            Controls.Add(btnClose);
            Controls.Add(groupBoxDanger);
            Controls.Add(groupBoxRestore);
            Controls.Add(groupBoxBackup);
            Controls.Add(groupBoxStats);
            Controls.Add(panelHeader);
            ForeColor = Color.FromArgb(127, 140, 141);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "BackupRestoreForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Backup & Restore - AUTO B&T";
            Load += BackupRestoreForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            groupBoxStats.ResumeLayout(false);
            groupBoxStats.PerformLayout();
            groupBoxBackup.ResumeLayout(false);
            groupBoxRestore.ResumeLayout(false);
            groupBoxDanger.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitle;
        private GroupBox groupBoxStats;
        private Label lblPartsCount;
        private Label lblServiceOrdersCount;
        private Label lblVehiclesCount;
        private Label lblCustomersCount;
        private Button btnRefreshStats;
        private GroupBox groupBoxBackup;
        private Label lblBackupInfo;
        private Button btnBackup;
        private GroupBox groupBoxRestore;
        private Label lblRestoreInfo;
        private Button btnRestore;
        private GroupBox groupBoxDanger;
        private Button btnClearDatabase;
        private Button btnClose;
    }
}