using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VehicleServiceManager.Data;
using VehicleServiceManager.Models;

namespace VehicleServiceManager.Forms
{
    public partial class PartsForm : Form
    {
        private VehicleServiceContext _context;
        private BindingSource _partsBindingSource = new BindingSource();

        public PartsForm()
        {
            InitializeComponent();

            Load += PartsForm_Load;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += btnClear_Click;
            btnSearch.Click += btnSearch_Click;
            btnRefresh.Click += btnRefresh_Click;

            dataParts.DataBindingComplete += dataParts_DataBindingComplete;
            dataParts.SelectionChanged += dataParts_SelectionChanged;
        }

        private void PartsForm_Load(object sender, EventArgs e)
        {
            _context = new VehicleServiceContext();
            _context.Database.EnsureCreated();
            LoadParts();
        }

        private void LoadParts()
        {
            _context.Parts.Load();

            _partsBindingSource.DataSource = _context.Parts.Local.ToBindingList();
            dataParts.DataSource = _partsBindingSource;
            dataParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataParts_SelectionChanged(object sender, EventArgs e)
        {
            if (dataParts.CurrentRow == null) return;
            if (dataParts.CurrentRow.DataBoundItem is not Part part) return;

            txtPartNumber.Text = part.PartNumber;
            txtPartName.Text = part.PartName;
            txtSupplier.Text = part.Supplier ?? "";

            numUnitPrice.Value = ClampToRange(part.UnitPrice, numUnitPrice.Minimum, numUnitPrice.Maximum);
            numStockQuantity.Value = ClampToRange(part.StockQuantity, numStockQuantity.Minimum, numStockQuantity.Maximum);
            numMinStock.Value = ClampToRange(part.MinStockLevel ?? 0, numMinStock.Minimum, numMinStock.Maximum);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidatePartInputs()) return;

            var part = new Part
            {
                PartNumber = txtPartNumber.Text.Trim(),
                PartName = txtPartName.Text.Trim(),
                Supplier = string.IsNullOrWhiteSpace(txtSupplier.Text) ? null : txtSupplier.Text.Trim(),
                UnitPrice = numUnitPrice.Value,
                StockQuantity = (int)numStockQuantity.Value,
                MinStockLevel = (int)numMinStock.Value == 0 ? null : (int)numMinStock.Value
            };

            _context.Parts.Add(part);
            _context.SaveChanges();

            LoadParts();
            ClearInputs();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataParts.CurrentRow == null)
            {
                MessageBox.Show("Please select a part to update.");
                return;
            }

            if (dataParts.CurrentRow.DataBoundItem is not Part part) return;
            if (!ValidatePartInputs()) return;

            part.PartNumber = txtPartNumber.Text.Trim();
            part.PartName = txtPartName.Text.Trim();
            part.Supplier = string.IsNullOrWhiteSpace(txtSupplier.Text) ? null : txtSupplier.Text.Trim();
            part.UnitPrice = numUnitPrice.Value;
            part.StockQuantity = (int)numStockQuantity.Value;
            part.MinStockLevel = (int)numMinStock.Value == 0 ? null : (int)numMinStock.Value;

            _context.SaveChanges();

            LoadParts();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataParts.CurrentRow == null)
            {
                MessageBox.Show("Please select a part to delete.");
                return;
            }

            if (dataParts.CurrentRow.DataBoundItem is not Part part) return;

            var confirm = MessageBox.Show(
                $"Delete part '{part.PartName}' ({part.PartNumber})?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            _context.Parts.Remove(part);
            _context.SaveChanges();

            LoadParts();
            ClearInputs();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string term = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(term))
            {
                LoadParts();
                return;
            }

            var results = _context.Parts
                .Where(p =>
                    p.PartNumber.ToLower().Contains(term) ||
                    p.PartName.ToLower().Contains(term) ||
                    (p.Supplier != null && p.Supplier.ToLower().Contains(term)))
                .OrderBy(p => p.PartName)
                .ToList();

            dataParts.DataSource = results;

            if (results.Count == 0)
                MessageBox.Show("No parts found matching your search.");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _context?.Dispose();
            _context = new VehicleServiceContext();

            LoadParts();
            txtSearch.Clear();
            ClearInputs();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
            dataParts.ClearSelection();
        }

        private bool ValidatePartInputs()
        {
            if (string.IsNullOrWhiteSpace(txtPartNumber.Text))
            {
                MessageBox.Show("Part Number is required.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPartName.Text))
            {
                MessageBox.Show("Part Name is required.");
                return false;
            }

            // DB requires UnitPrice NOT NULL and StockQuantity NOT NULL
            // (your schema sets a default for StockQuantity, but UI should still be valid) [file:217]
            if (numUnitPrice.Value < 0)
            {
                MessageBox.Show("Unit Price cannot be negative.");
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            txtPartNumber.Clear();
            txtPartName.Clear();
            txtSupplier.Clear();

            numUnitPrice.Value = 0;
            numStockQuantity.Value = 0;
            numMinStock.Value = 0;

            txtSearch.Clear();
        }

        // Highlight low-stock parts using Part.IsLowStock [file:219]
        private void dataParts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dataParts.Rows)
            {
                if (row.DataBoundItem is Part part && part.IsLowStock)
                    row.DefaultCellStyle.BackColor = Color.MistyRose;
                else
                    row.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private static decimal ClampToRange(decimal value, decimal min, decimal max)
            => value < min ? min : (value > max ? max : value);

        private static decimal ClampToRange(int value, decimal min, decimal max)
            => ClampToRange((decimal)value, min, max);

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            _context?.Dispose();
        }
    }
}
