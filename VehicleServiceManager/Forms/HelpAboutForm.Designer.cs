namespace VehicleServiceManager.Forms
{
    partial class HelpAboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpAboutForm));
            pnlHeader = new Panel();
            lblSubtitle = new Label();
            lblAppName = new Label();
            lblLogo = new Label();
            lblVersion = new Label();
            pnlSeparator1 = new Panel();
            lblDescHeader = new Label();
            lblDescription = new Label();
            pnlSeparator2 = new Panel();
            lblFeaturesHeader = new Label();
            lblFeatures = new Label();
            pnlSeparator3 = new Panel();
            lblTechHeader = new Label();
            lblTechnologies = new Label();
            pnlFooter = new Panel();
            lblStudent = new Label();
            lblCopyright = new Label();
            btnClose = new Button();
            pnlHeader.SuspendLayout();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(45, 45, 48);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblAppName);
            pnlHeader.Controls.Add(lblLogo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(584, 120);
            pnlHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            lblSubtitle.BackColor = Color.Transparent;
            lblSubtitle.Font = new Font("Segoe UI", 12F);
            lblSubtitle.ForeColor = Color.FromArgb(255, 193, 7);
            lblSubtitle.Location = new Point(130, 70);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(400, 25);
            lblSubtitle.TabIndex = 2;
            lblSubtitle.Text = "Vehicle Service Management System";
            // 
            // lblAppName
            // 
            lblAppName.BackColor = Color.Transparent;
            lblAppName.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAppName.Location = new Point(130, 30);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(400, 40);
            lblAppName.TabIndex = 1;
            lblAppName.Text = "AUTO B&&T";
            // 
            // lblLogo
            // 
            lblLogo.BackColor = Color.Transparent;
            lblLogo.Font = new Font("Segoe UI", 35F);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(30, 25);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(80, 70);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "🚗";
            // 
            // lblVersion
            // 
            lblVersion.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVersion.ForeColor = Color.FromArgb(63, 81, 181);
            lblVersion.Location = new Point(30, 140);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(540, 25);
            lblVersion.TabIndex = 1;
            lblVersion.Text = "Version 1.0.0";
            lblVersion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlSeparator1
            // 
            pnlSeparator1.BackColor = Color.Gainsboro;
            pnlSeparator1.Location = new Point(30, 175);
            pnlSeparator1.Name = "pnlSeparator1";
            pnlSeparator1.Size = new Size(540, 1);
            pnlSeparator1.TabIndex = 2;
            // 
            // lblDescHeader
            // 
            lblDescHeader.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDescHeader.ForeColor = Color.FromArgb(60, 60, 60);
            lblDescHeader.Location = new Point(30, 190);
            lblDescHeader.Name = "lblDescHeader";
            lblDescHeader.Size = new Size(540, 25);
            lblDescHeader.TabIndex = 3;
            lblDescHeader.Text = "About This Application";
            // 
            // lblDescription
            // 
            lblDescription.ForeColor = Color.FromArgb(80, 80, 80);
            lblDescription.Location = new Point(30, 220);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(540, 60);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "A comprehensive desktop application for managing vehicle service operations, including customer records, vehicle information, service orders, parts inventory, and automated invoice generation.";
            // 
            // pnlSeparator2
            // 
            pnlSeparator2.BackColor = Color.Gainsboro;
            pnlSeparator2.Location = new Point(30, 295);
            pnlSeparator2.Name = "pnlSeparator2";
            pnlSeparator2.Size = new Size(540, 1);
            pnlSeparator2.TabIndex = 5;
            // 
            // lblFeaturesHeader
            // 
            lblFeaturesHeader.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFeaturesHeader.ForeColor = Color.FromArgb(60, 60, 60);
            lblFeaturesHeader.Location = new Point(30, 310);
            lblFeaturesHeader.Name = "lblFeaturesHeader";
            lblFeaturesHeader.Size = new Size(540, 25);
            lblFeaturesHeader.TabIndex = 6;
            lblFeaturesHeader.Text = "Key Features";
            // 
            // lblFeatures
            // 
            lblFeatures.ForeColor = Color.FromArgb(80, 80, 80);
            lblFeatures.Location = new Point(30, 340);
            lblFeatures.Name = "lblFeatures";
            lblFeatures.Size = new Size(540, 140);
            lblFeatures.TabIndex = 7;
            lblFeatures.Text = resources.GetString("lblFeatures.Text");
            // 
            // pnlSeparator3
            // 
            pnlSeparator3.BackColor = Color.Gainsboro;
            pnlSeparator3.Location = new Point(30, 490);
            pnlSeparator3.Name = "pnlSeparator3";
            pnlSeparator3.Size = new Size(540, 1);
            pnlSeparator3.TabIndex = 8;
            // 
            // lblTechHeader
            // 
            lblTechHeader.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTechHeader.ForeColor = Color.FromArgb(60, 60, 60);
            lblTechHeader.Location = new Point(30, 505);
            lblTechHeader.Name = "lblTechHeader";
            lblTechHeader.Size = new Size(540, 25);
            lblTechHeader.TabIndex = 9;
            lblTechHeader.Text = "Technologies Used";
            // 
            // lblTechnologies
            // 
            lblTechnologies.ForeColor = Color.FromArgb(80, 80, 80);
            lblTechnologies.Location = new Point(30, 535);
            lblTechnologies.Name = "lblTechnologies";
            lblTechnologies.Size = new Size(540, 25);
            lblTechnologies.TabIndex = 10;
            lblTechnologies.Text = "Windows Forms - .NET 6+ - Entity Framework Core - SQL Server LocalDB - LINQ - QuestPDF";
            lblTechnologies.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = SystemColors.ButtonFace;
            pnlFooter.Controls.Add(lblStudent);
            pnlFooter.Controls.Add(lblCopyright);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 631);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(584, 80);
            pnlFooter.TabIndex = 11;
            // 
            // lblStudent
            // 
            lblStudent.BackColor = Color.Transparent;
            lblStudent.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblStudent.ForeColor = Color.FromArgb(120, 120, 120);
            lblStudent.Location = new Point(20, 35);
            lblStudent.Name = "lblStudent";
            lblStudent.Size = new Size(560, 20);
            lblStudent.TabIndex = 1;
            lblStudent.Text = "Developed by Berk Saliu and Tarik Emrulahi - Visual Programming Course Project 2025";
            lblStudent.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCopyright
            // 
            lblCopyright.BackColor = Color.Transparent;
            lblCopyright.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCopyright.ForeColor = SystemColors.WindowFrame;
            lblCopyright.Location = new Point(20, 15);
            lblCopyright.Name = "lblCopyright";
            lblCopyright.Size = new Size(560, 20);
            lblCopyright.TabIndex = 0;
            lblCopyright.Text = "© 2025 AUTO B&&T. All rights reserved.";
            lblCopyright.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(63, 81, 181);
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(240, 570);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(120, 40);
            btnClose.TabIndex = 12;
            btnClose.Text = "✓ OK";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // HelpAboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(584, 711);
            Controls.Add(btnClose);
            Controls.Add(pnlFooter);
            Controls.Add(lblTechnologies);
            Controls.Add(lblTechHeader);
            Controls.Add(pnlSeparator3);
            Controls.Add(lblFeatures);
            Controls.Add(lblFeaturesHeader);
            Controls.Add(pnlSeparator2);
            Controls.Add(lblDescription);
            Controls.Add(lblDescHeader);
            Controls.Add(pnlSeparator1);
            Controls.Add(lblVersion);
            Controls.Add(pnlHeader);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "HelpAboutForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "About - AUTO B&T";
            Load += HelpAboutForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblLogo;
        private Label lblAppName;
        private Label lblSubtitle;
        private Label lblVersion;
        private Panel pnlSeparator1;
        private Label lblDescHeader;
        private Label lblDescription;
        private Panel pnlSeparator2;
        private Label lblFeaturesHeader;
        private Label lblFeatures;
        private Panel pnlSeparator3;
        private Label lblTechHeader;
        private Label lblTechnologies;
        private Panel pnlFooter;
        private Label lblCopyright;
        private Label lblStudent;
        private Button btnClose;
    }
}