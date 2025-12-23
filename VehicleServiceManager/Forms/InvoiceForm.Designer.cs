namespace VehicleServiceManager.Forms
{
    partial class InvoiceForm
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
            pnlHeader = new Panel();
            lblDateHeader = new Label();
            lblInvoiceNumberHeader = new Label();
            lblSubtitle = new Label();
            lblCompanyName = new Label();
            pnlContent = new Panel();
            pnlTotal = new Panel();
            lblTotalAmount = new Label();
            lblTotalLabel = new Label();
            lblTaxAmount = new Label();
            lblTaxLabel = new Label();
            lblSubtotal = new Label();
            lblSubtotalLabel = new Label();
            pnlSeparator4 = new Panel();
            lblPartsCost = new Label();
            lblPartsLabel = new Label();
            lblLaborCost = new Label();
            lblLaborDetails = new Label();
            lblLaborLabel = new Label();
            pnlSeparator3 = new Panel();
            txtDescription = new TextBox();
            lblServiceHeader = new Label();
            pnlSeparator2 = new Panel();
            lblLicense = new Label();
            lblVIN = new Label();
            lblVehicleName = new Label();
            lblVehicleHeader = new Label();
            lblAddress = new Label();
            lblEmail = new Label();
            lblPhone = new Label();
            lblCustomerName = new Label();
            lblBillToHeader = new Label();
            pnlSeparator1 = new Panel();
            lblServiceDate = new Label();
            lblServiceDateLabel = new Label();
            lblInvoiceDetailsHeader = new Label();
            lblAmountDue = new Label();
            lblPaymentStatus = new Label();
            btnGeneratePDF = new Button();
            btnClose = new Button();
            btnPrint = new Button();
            btnPrintPreview = new Button();
            pnlHeader.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlTotal.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(45, 45, 48);
            pnlHeader.Controls.Add(lblDateHeader);
            pnlHeader.Controls.Add(lblInvoiceNumberHeader);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblCompanyName);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(886, 100);
            pnlHeader.TabIndex = 0;
            // 
            // lblDateHeader
            // 
            lblDateHeader.BackColor = Color.Transparent;
            lblDateHeader.ForeColor = SystemColors.ScrollBar;
            lblDateHeader.Location = new Point(650, 60);
            lblDateHeader.Name = "lblDateHeader";
            lblDateHeader.Size = new Size(220, 20);
            lblDateHeader.TabIndex = 3;
            lblDateHeader.Text = "14 December 2025";
            lblDateHeader.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblInvoiceNumberHeader
            // 
            lblInvoiceNumberHeader.BackColor = Color.Transparent;
            lblInvoiceNumberHeader.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInvoiceNumberHeader.ForeColor = Color.FromArgb(255, 193, 7);
            lblInvoiceNumberHeader.Location = new Point(650, 30);
            lblInvoiceNumberHeader.Name = "lblInvoiceNumberHeader";
            lblInvoiceNumberHeader.Size = new Size(220, 25);
            lblInvoiceNumberHeader.TabIndex = 2;
            lblInvoiceNumberHeader.Text = "INV-2025-0001";
            lblInvoiceNumberHeader.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSubtitle
            // 
            lblSubtitle.BackColor = Color.Transparent;
            lblSubtitle.ForeColor = Color.Gainsboro;
            lblSubtitle.Location = new Point(30, 55);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(300, 25);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Vehicle Service Invoice";
            // 
            // lblCompanyName
            // 
            lblCompanyName.BackColor = Color.Transparent;
            lblCompanyName.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCompanyName.ForeColor = Color.White;
            lblCompanyName.Location = new Point(30, 20);
            lblCompanyName.Name = "lblCompanyName";
            lblCompanyName.Size = new Size(400, 30);
            lblCompanyName.TabIndex = 0;
            lblCompanyName.Text = "AUTO B&&T";
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.White;
            pnlContent.BorderStyle = BorderStyle.FixedSingle;
            pnlContent.Controls.Add(pnlTotal);
            pnlContent.Controls.Add(lblTaxAmount);
            pnlContent.Controls.Add(lblTaxLabel);
            pnlContent.Controls.Add(lblSubtotal);
            pnlContent.Controls.Add(lblSubtotalLabel);
            pnlContent.Controls.Add(pnlSeparator4);
            pnlContent.Controls.Add(lblPartsCost);
            pnlContent.Controls.Add(lblPartsLabel);
            pnlContent.Controls.Add(lblLaborCost);
            pnlContent.Controls.Add(lblLaborDetails);
            pnlContent.Controls.Add(lblLaborLabel);
            pnlContent.Controls.Add(pnlSeparator3);
            pnlContent.Controls.Add(txtDescription);
            pnlContent.Controls.Add(lblServiceHeader);
            pnlContent.Controls.Add(pnlSeparator2);
            pnlContent.Controls.Add(lblLicense);
            pnlContent.Controls.Add(lblVIN);
            pnlContent.Controls.Add(lblVehicleName);
            pnlContent.Controls.Add(lblVehicleHeader);
            pnlContent.Controls.Add(lblAddress);
            pnlContent.Controls.Add(lblEmail);
            pnlContent.Controls.Add(lblPhone);
            pnlContent.Controls.Add(lblCustomerName);
            pnlContent.Controls.Add(lblBillToHeader);
            pnlContent.Controls.Add(pnlSeparator1);
            pnlContent.Controls.Add(lblServiceDate);
            pnlContent.Controls.Add(lblServiceDateLabel);
            pnlContent.Controls.Add(lblInvoiceDetailsHeader);
            pnlContent.Controls.Add(lblAmountDue);
            pnlContent.Controls.Add(lblPaymentStatus);
            pnlContent.Location = new Point(30, 120);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(840, 700);
            pnlContent.TabIndex = 1;
            // 
            // pnlTotal
            // 
            pnlTotal.BackColor = Color.FromArgb(38, 50, 56);
            pnlTotal.Controls.Add(lblTotalAmount);
            pnlTotal.Controls.Add(lblTotalLabel);
            pnlTotal.Location = new Point(450, 600);
            pnlTotal.Name = "pnlTotal";
            pnlTotal.Size = new Size(360, 50);
            pnlTotal.TabIndex = 29;
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.BackColor = Color.Transparent;
            lblTotalAmount.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalAmount.ForeColor = Color.FromArgb(255, 193, 7);
            lblTotalAmount.Location = new Point(180, 15);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(160, 20);
            lblTotalAmount.TabIndex = 1;
            lblTotalAmount.Text = "€0.00";
            lblTotalAmount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalLabel
            // 
            lblTotalLabel.BackColor = Color.Transparent;
            lblTotalLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalLabel.ForeColor = Color.White;
            lblTotalLabel.Location = new Point(20, 15);
            lblTotalLabel.Name = "lblTotalLabel";
            lblTotalLabel.Size = new Size(150, 20);
            lblTotalLabel.TabIndex = 0;
            lblTotalLabel.Text = "TOTAL";
            // 
            // lblTaxAmount
            // 
            lblTaxAmount.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTaxAmount.ForeColor = Color.Black;
            lblTaxAmount.Location = new Point(650, 565);
            lblTaxAmount.Name = "lblTaxAmount";
            lblTaxAmount.Size = new Size(160, 22);
            lblTaxAmount.TabIndex = 28;
            lblTaxAmount.Text = "€0.00";
            lblTaxAmount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTaxLabel
            // 
            lblTaxLabel.Font = new Font("Segoe UI", 10F);
            lblTaxLabel.ForeColor = Color.FromArgb(60, 60, 60);
            lblTaxLabel.Location = new Point(450, 565);
            lblTaxLabel.Name = "lblTaxLabel";
            lblTaxLabel.Size = new Size(180, 22);
            lblTaxLabel.TabIndex = 27;
            lblTaxLabel.Text = "Tax (18%)";
            // 
            // lblSubtotal
            // 
            lblSubtotal.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubtotal.ForeColor = Color.Black;
            lblSubtotal.Location = new Point(650, 535);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(160, 22);
            lblSubtotal.TabIndex = 26;
            lblSubtotal.Text = "€0.00";
            lblSubtotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSubtotalLabel
            // 
            lblSubtotalLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubtotalLabel.Location = new Point(450, 535);
            lblSubtotalLabel.Name = "lblSubtotalLabel";
            lblSubtotalLabel.Size = new Size(180, 22);
            lblSubtotalLabel.TabIndex = 25;
            lblSubtotalLabel.Text = "Subtotal";
            // 
            // pnlSeparator4
            // 
            pnlSeparator4.BackColor = SystemColors.ScrollBar;
            pnlSeparator4.Location = new Point(450, 520);
            pnlSeparator4.Name = "pnlSeparator4";
            pnlSeparator4.Size = new Size(360, 1);
            pnlSeparator4.TabIndex = 24;
            // 
            // lblPartsCost
            // 
            lblPartsCost.Font = new Font("Segoe UI", 10F);
            lblPartsCost.ForeColor = Color.Black;
            lblPartsCost.Location = new Point(650, 485);
            lblPartsCost.Name = "lblPartsCost";
            lblPartsCost.Size = new Size(160, 22);
            lblPartsCost.TabIndex = 23;
            lblPartsCost.Text = "€0.00";
            lblPartsCost.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPartsLabel
            // 
            lblPartsLabel.Font = new Font("Segoe UI", 10F);
            lblPartsLabel.ForeColor = Color.FromArgb(60, 60, 60);
            lblPartsLabel.Location = new Point(30, 485);
            lblPartsLabel.Name = "lblPartsLabel";
            lblPartsLabel.Size = new Size(400, 22);
            lblPartsLabel.TabIndex = 22;
            lblPartsLabel.Text = "Parts";
            // 
            // lblLaborCost
            // 
            lblLaborCost.Font = new Font("Segoe UI", 10F);
            lblLaborCost.ForeColor = Color.Black;
            lblLaborCost.Location = new Point(650, 430);
            lblLaborCost.Name = "lblLaborCost";
            lblLaborCost.Size = new Size(160, 22);
            lblLaborCost.TabIndex = 21;
            lblLaborCost.Text = "€0.00";
            lblLaborCost.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblLaborDetails
            // 
            lblLaborDetails.Font = new Font("Segoe UI", 8F);
            lblLaborDetails.ForeColor = Color.FromArgb(120, 120, 120);
            lblLaborDetails.Location = new Point(30, 455);
            lblLaborDetails.Name = "lblLaborDetails";
            lblLaborDetails.Size = new Size(400, 18);
            lblLaborDetails.TabIndex = 20;
            lblLaborDetails.Text = "0.0h @ €0.00/h";
            // 
            // lblLaborLabel
            // 
            lblLaborLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLaborLabel.ForeColor = Color.FromArgb(60, 60, 60);
            lblLaborLabel.Location = new Point(30, 430);
            lblLaborLabel.Name = "lblLaborLabel";
            lblLaborLabel.Size = new Size(400, 22);
            lblLaborLabel.TabIndex = 19;
            lblLaborLabel.Text = "Labor";
            // 
            // pnlSeparator3
            // 
            pnlSeparator3.BackColor = Color.Gainsboro;
            pnlSeparator3.Location = new Point(30, 405);
            pnlSeparator3.Name = "pnlSeparator3";
            pnlSeparator3.Size = new Size(780, 1);
            pnlSeparator3.TabIndex = 18;
            // 
            // txtDescription
            // 
            txtDescription.BackColor = Color.FromArgb(248, 248, 248);
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.ForeColor = Color.Black;
            txtDescription.Location = new Point(30, 305);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ReadOnly = true;
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(780, 80);
            txtDescription.TabIndex = 17;
            txtDescription.Text = "Service description will appear here.";
            // 
            // lblServiceHeader
            // 
            lblServiceHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblServiceHeader.ForeColor = Color.FromArgb(80, 80, 80);
            lblServiceHeader.Location = new Point(30, 275);
            lblServiceHeader.Name = "lblServiceHeader";
            lblServiceHeader.Size = new Size(250, 20);
            lblServiceHeader.TabIndex = 16;
            lblServiceHeader.Text = "SERVICE DESCRIPTION";
            // 
            // pnlSeparator2
            // 
            pnlSeparator2.BackColor = Color.Gainsboro;
            pnlSeparator2.Location = new Point(30, 255);
            pnlSeparator2.Name = "pnlSeparator2";
            pnlSeparator2.Size = new Size(780, 1);
            pnlSeparator2.TabIndex = 15;
            // 
            // lblLicense
            // 
            lblLicense.ForeColor = SystemColors.WindowFrame;
            lblLicense.Location = new Point(450, 194);
            lblLicense.Name = "lblLicense";
            lblLicense.Size = new Size(350, 18);
            lblLicense.TabIndex = 14;
            lblLicense.Text = "License: SK-1234-AB";
            // 
            // lblVIN
            // 
            lblVIN.ForeColor = SystemColors.WindowFrame;
            lblVIN.Location = new Point(450, 172);
            lblVIN.Name = "lblVIN";
            lblVIN.Size = new Size(350, 18);
            lblVIN.TabIndex = 13;
            lblVIN.Text = "VIN: WVWZZZAUZPE123456";
            // 
            // lblVehicleName
            // 
            lblVehicleName.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVehicleName.ForeColor = Color.Black;
            lblVehicleName.Location = new Point(450, 145);
            lblVehicleName.Name = "lblVehicleName";
            lblVehicleName.Size = new Size(350, 22);
            lblVehicleName.TabIndex = 12;
            lblVehicleName.Text = "2020 VW Golf 8";
            // 
            // lblVehicleHeader
            // 
            lblVehicleHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVehicleHeader.ForeColor = Color.FromArgb(80, 80, 80);
            lblVehicleHeader.Location = new Point(450, 115);
            lblVehicleHeader.Name = "lblVehicleHeader";
            lblVehicleHeader.Size = new Size(150, 20);
            lblVehicleHeader.TabIndex = 11;
            lblVehicleHeader.Text = "VEHICLE";
            // 
            // lblAddress
            // 
            lblAddress.ForeColor = SystemColors.WindowFrame;
            lblAddress.Location = new Point(30, 216);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(350, 18);
            lblAddress.TabIndex = 10;
            lblAddress.Text = "Road Example, Shkupi";
            // 
            // lblEmail
            // 
            lblEmail.ForeColor = SystemColors.WindowFrame;
            lblEmail.Location = new Point(30, 194);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(350, 18);
            lblEmail.TabIndex = 9;
            lblEmail.Text = "john.doe@email.com";
            // 
            // lblPhone
            // 
            lblPhone.ForeColor = SystemColors.WindowFrame;
            lblPhone.Location = new Point(30, 172);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(350, 18);
            lblPhone.TabIndex = 8;
            lblPhone.Text = "+389 XX XXX XXX";
            // 
            // lblCustomerName
            // 
            lblCustomerName.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCustomerName.ForeColor = Color.Black;
            lblCustomerName.Location = new Point(30, 145);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(350, 22);
            lblCustomerName.TabIndex = 7;
            lblCustomerName.Text = "John Doe";
            // 
            // lblBillToHeader
            // 
            lblBillToHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBillToHeader.ForeColor = Color.FromArgb(80, 80, 80);
            lblBillToHeader.Location = new Point(30, 115);
            lblBillToHeader.Name = "lblBillToHeader";
            lblBillToHeader.Size = new Size(150, 20);
            lblBillToHeader.TabIndex = 6;
            lblBillToHeader.Text = "BILL TO";
            // 
            // pnlSeparator1
            // 
            pnlSeparator1.BackColor = Color.Gainsboro;
            pnlSeparator1.Location = new Point(30, 95);
            pnlSeparator1.Name = "pnlSeparator1";
            pnlSeparator1.Size = new Size(780, 1);
            pnlSeparator1.TabIndex = 5;
            // 
            // lblServiceDate
            // 
            lblServiceDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblServiceDate.ForeColor = Color.Black;
            lblServiceDate.Location = new Point(140, 50);
            lblServiceDate.Name = "lblServiceDate";
            lblServiceDate.Size = new Size(150, 20);
            lblServiceDate.TabIndex = 4;
            lblServiceDate.Text = "14-Dec-2025";
            // 
            // lblServiceDateLabel
            // 
            lblServiceDateLabel.ForeColor = SystemColors.WindowFrame;
            lblServiceDateLabel.Location = new Point(30, 50);
            lblServiceDateLabel.Name = "lblServiceDateLabel";
            lblServiceDateLabel.Size = new Size(100, 20);
            lblServiceDateLabel.TabIndex = 3;
            lblServiceDateLabel.Text = "Service Date:";
            // 
            // lblInvoiceDetailsHeader
            // 
            lblInvoiceDetailsHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInvoiceDetailsHeader.ForeColor = Color.FromArgb(80, 80, 80);
            lblInvoiceDetailsHeader.Location = new Point(30, 20);
            lblInvoiceDetailsHeader.Name = "lblInvoiceDetailsHeader";
            lblInvoiceDetailsHeader.Size = new Size(105, 20);
            lblInvoiceDetailsHeader.TabIndex = 2;
            lblInvoiceDetailsHeader.Text = "INVOICE DETAILS";
            // 
            // lblAmountDue
            // 
            lblAmountDue.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAmountDue.Location = new Point(600, 60);
            lblAmountDue.Name = "lblAmountDue";
            lblAmountDue.Size = new Size(200, 25);
            lblAmountDue.TabIndex = 1;
            lblAmountDue.Text = "Amount Due: €0.00";
            lblAmountDue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPaymentStatus
            // 
            lblPaymentStatus.BackColor = Color.FromArgb(255, 235, 238);
            lblPaymentStatus.BorderStyle = BorderStyle.FixedSingle;
            lblPaymentStatus.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPaymentStatus.ForeColor = Color.FromArgb(183, 28, 28);
            lblPaymentStatus.Location = new Point(600, 20);
            lblPaymentStatus.Name = "lblPaymentStatus";
            lblPaymentStatus.Size = new Size(200, 35);
            lblPaymentStatus.TabIndex = 0;
            lblPaymentStatus.Text = "UNPAID";
            lblPaymentStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnGeneratePDF
            // 
            btnGeneratePDF.BackColor = Color.FromArgb(69, 90, 100);
            btnGeneratePDF.Cursor = Cursors.Hand;
            btnGeneratePDF.FlatAppearance.BorderSize = 0;
            btnGeneratePDF.FlatAppearance.MouseOverBackColor = Color.FromArgb(84, 110, 122);
            btnGeneratePDF.FlatStyle = FlatStyle.Flat;
            btnGeneratePDF.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGeneratePDF.ForeColor = Color.White;
            btnGeneratePDF.Location = new Point(140, 840);
            btnGeneratePDF.Name = "btnGeneratePDF";
            btnGeneratePDF.Size = new Size(160, 40);
            btnGeneratePDF.TabIndex = 2;
            btnGeneratePDF.Text = "Generate PDF";
            btnGeneratePDF.UseVisualStyleBackColor = false;
            btnGeneratePDF.Click += btnGeneratePDF_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(189, 189, 189);
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(158, 158, 158);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.FromArgb(60, 60, 60);
            btnClose.Location = new Point(680, 840);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(160, 40);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.FromArgb(103, 58, 183);
            btnPrint.Cursor = Cursors.Hand;
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(320, 840);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(160, 40);
            btnPrint.TabIndex = 4;
            btnPrint.Text = "🖨️ Print Invoice";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnPrintPreview
            // 
            btnPrintPreview.BackColor = Color.FromArgb(96, 125, 139);
            btnPrintPreview.Cursor = Cursors.Hand;
            btnPrintPreview.FlatAppearance.BorderSize = 0;
            btnPrintPreview.FlatStyle = FlatStyle.Flat;
            btnPrintPreview.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPrintPreview.ForeColor = Color.White;
            btnPrintPreview.Location = new Point(500, 840);
            btnPrintPreview.Name = "btnPrintPreview";
            btnPrintPreview.Size = new Size(160, 40);
            btnPrintPreview.TabIndex = 5;
            btnPrintPreview.Text = "👁️ Preview";
            btnPrintPreview.UseVisualStyleBackColor = false;
            btnPrintPreview.Click += btnPrintPreview_Click;
            // 
            // InvoiceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(250, 250, 250);
            ClientSize = new Size(903, 791);
            Controls.Add(btnPrintPreview);
            Controls.Add(btnPrint);
            Controls.Add(btnClose);
            Controls.Add(btnGeneratePDF);
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InvoiceForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Invoice Preview - AUTO B&T";
            Load += InvoiceForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            pnlTotal.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblCompanyName;
        private Label lblSubtitle;
        private Label lblInvoiceNumberHeader;
        private Label lblDateHeader;
        private Panel pnlContent;
        private Label lblPaymentStatus;
        private Label lblAmountDue;
        private Label lblServiceDate;
        private Label lblServiceDateLabel;
        private Label lblInvoiceDetailsHeader;
        private Panel pnlSeparator1;
        private Label lblAddress;
        private Label lblEmail;
        private Label lblPhone;
        private Label lblCustomerName;
        private Label lblBillToHeader;
        private Label lblLicense;
        private Label lblVIN;
        private Label lblVehicleName;
        private Label lblVehicleHeader;
        private Panel pnlSeparator2;
        private Label lblServiceHeader;
        private TextBox txtDescription;
        private Panel pnlSeparator3;
        private Label lblLaborLabel;
        private Label lblPartsCost;
        private Label lblPartsLabel;
        private Label lblLaborCost;
        private Label lblLaborDetails;
        private Label lblTaxAmount;
        private Label lblTaxLabel;
        private Label lblSubtotal;
        private Label lblSubtotalLabel;
        private Panel pnlSeparator4;
        private Panel pnlTotal;
        private Label lblTotalAmount;
        private Label lblTotalLabel;
        private Button btnGeneratePDF;
        private Button btnClose;
        private Button btnPrint;
        private Button btnPrintPreview;
    }
}