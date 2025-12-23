namespace VehicleServiceManager.Forms
{
    partial class PartsForm
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
            txtSearch = new TextBox();
            btnSearch = new Button();
            grpPartDetails = new GroupBox();
            lblMinStockLvl = new Label();
            lblStockQuantity = new Label();
            lblUnitPrice = new Label();
            lblSupplier = new Label();
            lblPartName = new Label();
            lblPartNumber = new Label();
            numMinStock = new NumericUpDown();
            numStockQuantity = new NumericUpDown();
            numUnitPrice = new NumericUpDown();
            txtSupplier = new TextBox();
            txtPartName = new TextBox();
            txtPartNumber = new TextBox();
            lblSearch = new Label();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            btnRefresh = new Button();
            dataParts = new DataGridView();
            grpPartDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMinStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStockQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numUnitPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataParts).BeginInit();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(92, 16);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(171, 27);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.LightSteelBlue;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.Location = new Point(274, 16);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(68, 28);
            btnSearch.TabIndex = 26;
            btnSearch.Text = "🔍 Filter";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // grpPartDetails
            // 
            grpPartDetails.Controls.Add(lblMinStockLvl);
            grpPartDetails.Controls.Add(lblStockQuantity);
            grpPartDetails.Controls.Add(lblUnitPrice);
            grpPartDetails.Controls.Add(lblSupplier);
            grpPartDetails.Controls.Add(lblPartName);
            grpPartDetails.Controls.Add(lblPartNumber);
            grpPartDetails.Controls.Add(numMinStock);
            grpPartDetails.Controls.Add(numStockQuantity);
            grpPartDetails.Controls.Add(numUnitPrice);
            grpPartDetails.Controls.Add(txtSupplier);
            grpPartDetails.Controls.Add(txtPartName);
            grpPartDetails.Controls.Add(txtPartNumber);
            grpPartDetails.Location = new Point(12, 71);
            grpPartDetails.Name = "grpPartDetails";
            grpPartDetails.Size = new Size(378, 330);
            grpPartDetails.TabIndex = 27;
            grpPartDetails.TabStop = false;
            grpPartDetails.Text = "Part Details";
            // 
            // lblMinStockLvl
            // 
            lblMinStockLvl.AutoSize = true;
            lblMinStockLvl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMinStockLvl.Location = new Point(24, 283);
            lblMinStockLvl.Name = "lblMinStockLvl";
            lblMinStockLvl.Size = new Size(137, 23);
            lblMinStockLvl.TabIndex = 37;
            lblMinStockLvl.Text = "Min Stock Level";
            lblMinStockLvl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStockQuantity
            // 
            lblStockQuantity.AutoSize = true;
            lblStockQuantity.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStockQuantity.Location = new Point(24, 238);
            lblStockQuantity.Name = "lblStockQuantity";
            lblStockQuantity.Size = new Size(130, 23);
            lblStockQuantity.TabIndex = 36;
            lblStockQuantity.Text = "Stock Quantity";
            // 
            // lblUnitPrice
            // 
            lblUnitPrice.AutoSize = true;
            lblUnitPrice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUnitPrice.Location = new Point(24, 188);
            lblUnitPrice.Name = "lblUnitPrice";
            lblUnitPrice.Size = new Size(88, 23);
            lblUnitPrice.TabIndex = 35;
            lblUnitPrice.Text = "Unit Price";
            // 
            // lblSupplier
            // 
            lblSupplier.AutoSize = true;
            lblSupplier.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSupplier.Location = new Point(24, 137);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(78, 23);
            lblSupplier.TabIndex = 34;
            lblSupplier.Text = "Supplier";
            // 
            // lblPartName
            // 
            lblPartName.AutoSize = true;
            lblPartName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPartName.Location = new Point(24, 82);
            lblPartName.Name = "lblPartName";
            lblPartName.Size = new Size(95, 23);
            lblPartName.TabIndex = 33;
            lblPartName.Text = "Part Name";
            // 
            // lblPartNumber
            // 
            lblPartNumber.AutoSize = true;
            lblPartNumber.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPartNumber.Location = new Point(24, 36);
            lblPartNumber.Name = "lblPartNumber";
            lblPartNumber.Size = new Size(114, 23);
            lblPartNumber.TabIndex = 32;
            lblPartNumber.Text = "Part Number";
            // 
            // numMinStock
            // 
            numMinStock.Location = new Point(180, 279);
            numMinStock.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numMinStock.Name = "numMinStock";
            numMinStock.Size = new Size(150, 27);
            numMinStock.TabIndex = 5;
            // 
            // numStockQuantity
            // 
            numStockQuantity.Location = new Point(180, 234);
            numStockQuantity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numStockQuantity.Name = "numStockQuantity";
            numStockQuantity.Size = new Size(150, 27);
            numStockQuantity.TabIndex = 4;
            // 
            // numUnitPrice
            // 
            numUnitPrice.DecimalPlaces = 2;
            numUnitPrice.Increment = new decimal(new int[] { 10, 0, 0, 131072 });
            numUnitPrice.Location = new Point(180, 184);
            numUnitPrice.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numUnitPrice.Name = "numUnitPrice";
            numUnitPrice.Size = new Size(150, 27);
            numUnitPrice.TabIndex = 3;
            // 
            // txtSupplier
            // 
            txtSupplier.Location = new Point(180, 133);
            txtSupplier.Name = "txtSupplier";
            txtSupplier.Size = new Size(150, 27);
            txtSupplier.TabIndex = 2;
            // 
            // txtPartName
            // 
            txtPartName.Location = new Point(180, 82);
            txtPartName.Name = "txtPartName";
            txtPartName.Size = new Size(150, 27);
            txtPartName.TabIndex = 1;
            // 
            // txtPartNumber
            // 
            txtPartNumber.Location = new Point(180, 36);
            txtPartNumber.Name = "txtPartNumber";
            txtPartNumber.Size = new Size(150, 27);
            txtPartNumber.TabIndex = 0;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSearch.Location = new Point(12, 16);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(63, 23);
            lblSearch.TabIndex = 28;
            lblSearch.Text = "Search";
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.LightGray;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Location = new Point(747, 16);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(91, 60);
            btnClear.TabIndex = 32;
            btnClear.Text = "🔄 Clear";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.LightCoral;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(553, 16);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(91, 60);
            btnDelete.TabIndex = 31;
            btnDelete.Text = "🗑️ Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.DeepSkyBlue;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Location = new Point(650, 16);
            btnUpdate.Margin = new Padding(3, 4, 3, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(91, 60);
            btnUpdate.TabIndex = 30;
            btnUpdate.Text = "📝 Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.LightGreen;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Location = new Point(456, 16);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(91, 60);
            btnAdd.TabIndex = 29;
            btnAdd.Text = "➕ Add New";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(363, 16);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(69, 28);
            btnRefresh.TabIndex = 33;
            btnRefresh.Text = "🔄 Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // dataParts
            // 
            dataParts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataParts.Location = new Point(456, 107);
            dataParts.Name = "dataParts";
            dataParts.RowHeadersWidth = 51;
            dataParts.Size = new Size(382, 294);
            dataParts.TabIndex = 34;
            // 
            // PartsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(868, 450);
            Controls.Add(dataParts);
            Controls.Add(btnRefresh);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(lblSearch);
            Controls.Add(grpPartDetails);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Name = "PartsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PartsForm";
            grpPartDetails.ResumeLayout(false);
            grpPartDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMinStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStockQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numUnitPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataParts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtSearch;
        private Button btnSearch;
        private GroupBox grpPartDetails;
        private TextBox txtSupplier;
        private TextBox txtPartName;
        private TextBox txtPartNumber;
        private NumericUpDown numUnitPrice;
        private NumericUpDown numMinStock;
        private NumericUpDown numStockQuantity;
        private Label lblSearch;
        private Label lblMinStockLvl;
        private Label lblStockQuantity;
        private Label lblUnitPrice;
        private Label lblSupplier;
        private Label lblPartName;
        private Label lblPartNumber;
        private Button btnClear;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private Button btnRefresh;
        private DataGridView dataParts;
    }
}