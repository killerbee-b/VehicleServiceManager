using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using VehicleServiceManager.Data;
using VehicleServiceManager.Models;

namespace VehicleServiceManager.Forms
{
    public partial class ErrorCodesForm : Form
    {
        private VehicleServiceContext? _context;

        // DTO for import/export
        private sealed class ErrorImportRow
        {
            public int VehicleID { get; set; }
            public string Code { get; set; } = "";
            public string Title { get; set; } = "";
            public string Module { get; set; } = "Engine";
            public string Severity { get; set; } = "Info";
            public string? Symptoms { get; set; }
            public string? Guide { get; set; }
            public DateTime? LoggedAt { get; set; }
            public string? Notes { get; set; }
        }

        public ErrorCodesForm()
        {
            InitializeComponent();

            // Designer already wires Load += ErrorCodesForm_Load and ImportCsv += button1_Click.
            // Wire the rest safely here:
            btnFilter.Click += btnFilter_Click;
            btnClearFilter.Click += btnClearFilter_Click;

            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnReset.Click += btnReset_Click;

            dataErrorCodes.SelectionChanged += dataErrorCodes_SelectionChanged;

            btnExportCsv.Click += btnExportCsv_Click;
            btnImportJson.Click += btnImportJson_Click;
            btnExportJson.Click += btnExportJson_Click;
        }

        // === Required because Designer has: btnImportCsv.Click += button1_Click;
        private void button1_Click(object? sender, EventArgs e) => btnImportCsv_Click(sender, e);

        private void ErrorCodesForm_Load(object? sender, EventArgs e)
        {
            _context = new VehicleServiceContext();
            _context.Database.EnsureCreated();

            SetupGrid();
            LoadModuleCombos();
            LoadSeverityCombo();
            LoadVehicleCombo();

            RefreshGrid();
        }

        // ===== Helpers =====
        private bool TryGetContext(out VehicleServiceContext context)
        {
            if (_context == null)
            {
                MessageBox.Show("Database context is not initialized. Close and reopen the form.");
                context = null!;
                return false;
            }
            context = _context;
            return true;
        }

        private int GetSelectedVehicleId()
        {
            return (cmbVehicle.SelectedValue is int id) ? id : 0;
        }

        private static string? NullIfBlank(string? s) => string.IsNullOrWhiteSpace(s) ? null : s.Trim();

        private static string Csv(string? value)
        {
            if (string.IsNullOrEmpty(value)) return "";
            var v = value.Replace("\"", "\"\"");
            return $"\"{v}\"";
        }

        private static bool SeverityOk(string s)
        {
            s = s.Trim();
            return s == "Info" || s == "Warning" || s == "Critical";
        }

        private void SetupGrid()
        {
            dataErrorCodes.ReadOnly = true;
            dataErrorCodes.MultiSelect = false;
            dataErrorCodes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataErrorCodes.AllowUserToAddRows = false;
            dataErrorCodes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadModuleCombos()
        {
            cmbModule.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModule.Items.Clear();
            cmbModule.Items.AddRange(new object[] { "All", "Engine", "ABS", "Transmission", "Body", "Airbag" });
            cmbModule.SelectedIndex = 0;

            cmbDetailModule.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDetailModule.Items.Clear();
            cmbDetailModule.Items.AddRange(new object[] { "Engine", "ABS", "Transmission", "Body", "Airbag" });
            cmbDetailModule.SelectedIndex = 0;
        }

        private void LoadSeverityCombo()
        {
            cmbSeverity.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSeverity.Items.Clear();
            cmbSeverity.Items.AddRange(new object[] { "Info", "Warning", "Critical" });
            cmbSeverity.SelectedIndex = 0;
        }

        private void LoadVehicleCombo()
        {
            if (!TryGetContext(out var context)) return;

            cmbVehicle.DropDownStyle = ComboBoxStyle.DropDownList;

            var vehicles = context.Vehicles
                .Include(v => v.Customer)
                .OrderBy(v => v.Make)
                .ThenBy(v => v.Model)
                .Select(v => new
                {
                    v.VehicleID,
                    DisplayText =
                        v.Customer != null
                            ? $"{v.Year} {v.Make} {v.Model} - {v.Customer.FullName}"
                            : $"{v.Year} {v.Make} {v.Model}"
                })
                .ToList();

            // Filter only; Add/Update requires choosing a specific vehicle (VehicleID != 0)
            vehicles.Insert(0, new { VehicleID = 0, DisplayText = "All Vehicles (Filter)" });

            cmbVehicle.DataSource = vehicles;
            cmbVehicle.DisplayMember = "DisplayText";
            cmbVehicle.ValueMember = "VehicleID";
            cmbVehicle.SelectedIndex = 0;
        }

        // ===== Grid Load / Filter =====
        private void btnFilter_Click(object? sender, EventArgs e) => RefreshGrid();

        private void btnClearFilter_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbModule.SelectedIndex = 0;
            cmbVehicle.SelectedIndex = 0;
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            if (!TryGetContext(out var context)) return;

            string term = txtSearch.Text.Trim().ToLowerInvariant();
            string moduleFilter = cmbModule.SelectedItem?.ToString() ?? "All";
            int vehicleId = GetSelectedVehicleId();

            var query = context.VehicleErrorCodes
                .Include(x => x.Vehicle).ThenInclude(v => v.Customer)
                .Include(x => x.ErrorCode)
                .AsQueryable();

            if (vehicleId != 0)
                query = query.Where(x => x.VehicleID == vehicleId);

            if (moduleFilter != "All")
                query = query.Where(x => x.ErrorCode != null && x.ErrorCode.Module == moduleFilter);

            if (!string.IsNullOrWhiteSpace(term))
            {
                query = query.Where(x =>
                    x.ErrorCode != null &&
                    (x.ErrorCode.Code.ToLower().Contains(term) ||
                     x.ErrorCode.Title.ToLower().Contains(term) ||
                     (x.ErrorCode.Symptoms ?? "").ToLower().Contains(term) ||
                     (x.ErrorCode.Guide ?? "").ToLower().Contains(term) ||
                     (x.Notes ?? "").ToLower().Contains(term)));
            }

            var rows = query
                .OrderByDescending(x => x.LoggedAt)
                .Select(x => new
                {
                    x.VehicleErrorCodeID,
                    x.VehicleID,
                    Vehicle = x.Vehicle != null ? $"{x.Vehicle.Year} {x.Vehicle.Make} {x.Vehicle.Model}" : "",
                    Customer = (x.Vehicle != null && x.Vehicle.Customer != null) ? x.Vehicle.Customer.FullName : "",
                    Code = x.ErrorCode != null ? x.ErrorCode.Code : "",
                    Title = x.ErrorCode != null ? x.ErrorCode.Title : "",
                    Module = x.ErrorCode != null ? x.ErrorCode.Module : "",
                    Severity = x.ErrorCode != null ? x.ErrorCode.Severity : "",
                    LoggedAt = x.LoggedAt,
                    Notes = x.Notes
                })
                .ToList();

            dataErrorCodes.DataSource = rows;

            if (dataErrorCodes.Columns["VehicleErrorCodeID"] != null)
                dataErrorCodes.Columns["VehicleErrorCodeID"].Visible = false;
            if (dataErrorCodes.Columns["VehicleID"] != null)
                dataErrorCodes.Columns["VehicleID"].Visible = false;
        }

        private void dataErrorCodes_SelectionChanged(object? sender, EventArgs e)
        {
            if (!TryGetContext(out var context)) return;
            if (dataErrorCodes.CurrentRow == null) return;

            var cell = dataErrorCodes.CurrentRow.Cells["VehicleErrorCodeID"]?.Value;
            if (cell == null) return;

            int vecId = Convert.ToInt32(cell);

            var record = context.VehicleErrorCodes
                .Include(x => x.ErrorCode)
                .FirstOrDefault(x => x.VehicleErrorCodeID == vecId);

            if (record?.ErrorCode == null) return;

            cmbVehicle.SelectedValue = record.VehicleID;

            txtCode.Text = record.ErrorCode.Code;
            txtTitle.Text = record.ErrorCode.Title;
            cmbDetailModule.SelectedItem = record.ErrorCode.Module;
            cmbSeverity.SelectedItem = record.ErrorCode.Severity;
            txtSymptoms.Text = record.ErrorCode.Symptoms ?? "";
            txtFixGuide.Text = record.ErrorCode.Guide ?? "";
        }

        // ===== CRUD =====
        private void btnReset_Click(object? sender, EventArgs e) => ClearEditor();

        private void ClearEditor()
        {
            txtCode.Clear();
            txtTitle.Clear();
            txtSymptoms.Clear();
            txtFixGuide.Clear();

            if (cmbDetailModule.Items.Count > 0) cmbDetailModule.SelectedIndex = 0;
            if (cmbSeverity.Items.Count > 0) cmbSeverity.SelectedIndex = 0;
        }

        private bool ValidateInputs(bool requireVehicle)
        {
            if (requireVehicle && GetSelectedVehicleId() == 0)
            {
                MessageBox.Show("Select a specific vehicle (not 'All Vehicles').");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("DTC Code is required (example: P0300).");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Title is required.");
                return false;
            }

            if (cmbDetailModule.SelectedItem == null)
            {
                MessageBox.Show("Module is required.");
                return false;
            }

            if (cmbSeverity.SelectedItem == null || !SeverityOk(cmbSeverity.SelectedItem.ToString() ?? ""))
            {
                MessageBox.Show("Severity must be Info, Warning, or Critical.");
                return false;
            }

            return true;
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (!TryGetContext(out var context)) return;
            if (!ValidateInputs(requireVehicle: true)) return;

            int vehicleId = GetSelectedVehicleId();
            string code = txtCode.Text.Trim().ToUpperInvariant();

            // Ensure ErrorCode exists (unique by Code)
            var errorCode = context.ErrorCodes.FirstOrDefault(x => x.Code == code);
            if (errorCode == null)
            {
                errorCode = new ErrorCode
                {
                    Code = code,
                    Title = txtTitle.Text.Trim(),
                    Module = cmbDetailModule.SelectedItem?.ToString() ?? "Engine",
                    Severity = cmbSeverity.SelectedItem?.ToString() ?? "Info",
                    Symptoms = NullIfBlank(txtSymptoms.Text),
                    Guide = NullIfBlank(txtFixGuide.Text)
                };
                context.ErrorCodes.Add(errorCode);
                context.SaveChanges();
            }
            else
            {
                // Update definition (optional)
                errorCode.Title = txtTitle.Text.Trim();
                errorCode.Module = cmbDetailModule.SelectedItem?.ToString() ?? errorCode.Module;
                errorCode.Severity = cmbSeverity.SelectedItem?.ToString() ?? errorCode.Severity;
                errorCode.Symptoms = NullIfBlank(txtSymptoms.Text);
                errorCode.Guide = NullIfBlank(txtFixGuide.Text);
                context.SaveChanges();
            }

            // Add per-vehicle record
            bool alreadyAssigned = context.VehicleErrorCodes
                .Any(x => x.VehicleID == vehicleId && x.ErrorCodeID == errorCode.ErrorCodeID);

            if (alreadyAssigned)
            {
                MessageBox.Show("This code is already assigned to the selected vehicle.");
                return;
            }

            context.VehicleErrorCodes.Add(new VehicleErrorCode
            {
                VehicleID = vehicleId,
                ErrorCodeID = errorCode.ErrorCodeID,
                LoggedAt = DateTime.Now,
                Notes = null
            });

            context.SaveChanges();
            RefreshGrid();
            ClearEditor();
        }

        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (!TryGetContext(out var context)) return;
            if (!ValidateInputs(requireVehicle: true)) return;

            if (dataErrorCodes.CurrentRow == null ||
                dataErrorCodes.CurrentRow.Cells["VehicleErrorCodeID"]?.Value == null)
            {
                MessageBox.Show("Select a record to update.");
                return;
            }

            int recId = Convert.ToInt32(dataErrorCodes.CurrentRow.Cells["VehicleErrorCodeID"].Value);
            int vehicleId = GetSelectedVehicleId();

            var record = context.VehicleErrorCodes
                .Include(x => x.ErrorCode)
                .FirstOrDefault(x => x.VehicleErrorCodeID == recId);

            if (record?.ErrorCode == null) return;

            record.VehicleID = vehicleId;

            // NOTE: Code change is not supported here (because Code is unique).
            record.ErrorCode.Title = txtTitle.Text.Trim();
            record.ErrorCode.Module = cmbDetailModule.SelectedItem?.ToString() ?? record.ErrorCode.Module;
            record.ErrorCode.Severity = cmbSeverity.SelectedItem?.ToString() ?? record.ErrorCode.Severity;
            record.ErrorCode.Symptoms = NullIfBlank(txtSymptoms.Text);
            record.ErrorCode.Guide = NullIfBlank(txtFixGuide.Text);

            context.SaveChanges();
            RefreshGrid();
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (!TryGetContext(out var context)) return;

            if (dataErrorCodes.CurrentRow == null ||
                dataErrorCodes.CurrentRow.Cells["VehicleErrorCodeID"]?.Value == null)
            {
                MessageBox.Show("Select a record to delete.");
                return;
            }

            int recId = Convert.ToInt32(dataErrorCodes.CurrentRow.Cells["VehicleErrorCodeID"].Value);

            var record = context.VehicleErrorCodes.FirstOrDefault(x => x.VehicleErrorCodeID == recId);
            if (record == null) return;

            var confirm = MessageBox.Show("Delete this vehicle error record?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            context.VehicleErrorCodes.Remove(record);
            context.SaveChanges();

            RefreshGrid();
            ClearEditor();
        }

        // ===== Import / Export =====
        private void btnImportCsv_Click(object? sender, EventArgs e)
        {
            if (!TryGetContext(out var context)) return;

            using var ofd = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                Title = "Import error codes (CSV)"
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            int createdErrorCodes = 0;
            int createdVehicleErrorCodes = 0;
            int skipped = 0;

            try
            {
                using var parser = new TextFieldParser(ofd.FileName, Encoding.UTF8);
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;

                if (parser.EndOfData)
                {
                    MessageBox.Show("CSV is empty.");
                    return;
                }

                var header = parser.ReadFields();
                if (header == null)
                {
                    MessageBox.Show("CSV header missing.");
                    return;
                }

                var col = header
                    .Select((name, idx) => new { name = name.Trim(), idx })
                    .ToDictionary(x => x.name, x => x.idx, StringComparer.OrdinalIgnoreCase);

                string[] required = { "VehicleID", "Code", "Title", "Module", "Severity" };
                foreach (var r in required)
                {
                    if (!col.ContainsKey(r))
                    {
                        MessageBox.Show($"CSV missing required column: {r}");
                        return;
                    }
                }

                while (!parser.EndOfData)
                {
                    var f = parser.ReadFields();
                    if (f == null || f.Length == 0) continue;

                    var row = new ErrorImportRow
                    {
                        VehicleID = int.TryParse(f[col["VehicleID"]], out var vid) ? vid : 0,
                        Code = (f[col["Code"]] ?? "").Trim().ToUpperInvariant(),
                        Title = (f[col["Title"]] ?? "").Trim(),
                        Module = (f[col["Module"]] ?? "Engine").Trim(),
                        Severity = (f[col["Severity"]] ?? "Info").Trim(),
                        Symptoms = col.ContainsKey("Symptoms") ? NullIfBlank(f[col["Symptoms"]]) : null,
                        Guide = col.ContainsKey("Guide") ? NullIfBlank(f[col["Guide"]]) : null,
                        Notes = col.ContainsKey("Notes") ? NullIfBlank(f[col["Notes"]]) : null
                    };

                    if (col.ContainsKey("LoggedAt"))
                    {
                        var raw = f[col["LoggedAt"]];
                        if (!string.IsNullOrWhiteSpace(raw) &&
                            DateTime.TryParse(raw, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out var dt))
                            row.LoggedAt = dt;
                    }

                    if (!ValidateImportRow(context, row))
                    {
                        skipped++;
                        continue;
                    }

                    if (!context.Vehicles.Any(v => v.VehicleID == row.VehicleID))
                    {
                        skipped++;
                        continue;
                    }

                    var errorCode = context.ErrorCodes.FirstOrDefault(e => e.Code == row.Code);
                    if (errorCode == null)
                    {
                        errorCode = new ErrorCode
                        {
                            Code = row.Code,
                            Title = row.Title,
                            Module = row.Module,
                            Severity = row.Severity,
                            Symptoms = row.Symptoms,
                            Guide = row.Guide
                        };
                        context.ErrorCodes.Add(errorCode);
                        context.SaveChanges();
                        createdErrorCodes++;
                    }
                    else
                    {
                        // optional update
                        errorCode.Title = row.Title;
                        errorCode.Module = row.Module;
                        errorCode.Severity = row.Severity;
                        errorCode.Symptoms = row.Symptoms;
                        errorCode.Guide = row.Guide;
                        context.SaveChanges();
                    }

                    bool exists = context.VehicleErrorCodes.Any(x =>
                        x.VehicleID == row.VehicleID && x.ErrorCodeID == errorCode.ErrorCodeID);

                    if (exists)
                    {
                        skipped++;
                        continue;
                    }

                    context.VehicleErrorCodes.Add(new VehicleErrorCode
                    {
                        VehicleID = row.VehicleID,
                        ErrorCodeID = errorCode.ErrorCodeID,
                        LoggedAt = row.LoggedAt ?? DateTime.Now,
                        Notes = row.Notes
                    });
                    context.SaveChanges();
                    createdVehicleErrorCodes++;
                }

                RefreshGrid();
                MessageBox.Show($"Import finished.\nNew ErrorCodes: {createdErrorCodes}\nNew VehicleErrorCodes: {createdVehicleErrorCodes}\nSkipped: {skipped}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"CSV import failed: {ex.Message}");
            }
        }

        private void btnExportCsv_Click(object? sender, EventArgs e)
        {
            if (!TryGetContext(out var context)) return;

            using var sfd = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                Title = "Export error codes (CSV)",
                FileName = "vehicle_error_codes.csv"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                var data = BuildExportQuery(context).ToList();

                using var sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8);
                sw.WriteLine("VehicleID,Code,Title,Module,Severity,Symptoms,Guide,LoggedAt,Notes");

                foreach (var r in data)
                {
                    sw.WriteLine(string.Join(",",
                        r.VehicleID.ToString(CultureInfo.InvariantCulture),
                        Csv(r.Code),
                        Csv(r.Title),
                        Csv(r.Module),
                        Csv(r.Severity),
                        Csv(r.Symptoms),
                        Csv(r.Guide),
                        Csv(r.LoggedAt?.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)),
                        Csv(r.Notes)
                    ));
                }

                MessageBox.Show("CSV export completed.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"CSV export failed: {ex.Message}");
            }
        }

        private void btnImportJson_Click(object? sender, EventArgs e)
        {
            if (!TryGetContext(out var context)) return;

            using var ofd = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                Title = "Import error codes (JSON)"
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                var json = File.ReadAllText(ofd.FileName, Encoding.UTF8);

                var rows = JsonSerializer.Deserialize<List<ErrorImportRow>>(
                    json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                if (rows == null || rows.Count == 0)
                {
                    MessageBox.Show("JSON is empty or invalid.");
                    return;
                }

                int createdErrorCodes = 0;
                int createdVehicleErrorCodes = 0;
                int skipped = 0;

                foreach (var row in rows)
                {
                    row.Code = (row.Code ?? "").Trim().ToUpperInvariant();
                    row.Title = (row.Title ?? "").Trim();
                    row.Module = (row.Module ?? "Engine").Trim();
                    row.Severity = (row.Severity ?? "Info").Trim();

                    if (!ValidateImportRow(context, row)) { skipped++; continue; }
                    if (!context.Vehicles.Any(v => v.VehicleID == row.VehicleID)) { skipped++; continue; }

                    var errorCode = context.ErrorCodes.FirstOrDefault(e => e.Code == row.Code);
                    if (errorCode == null)
                    {
                        errorCode = new ErrorCode
                        {
                            Code = row.Code,
                            Title = row.Title,
                            Module = row.Module,
                            Severity = row.Severity,
                            Symptoms = row.Symptoms,
                            Guide = row.Guide
                        };
                        context.ErrorCodes.Add(errorCode);
                        context.SaveChanges();
                        createdErrorCodes++;
                    }
                    else
                    {
                        errorCode.Title = row.Title;
                        errorCode.Module = row.Module;
                        errorCode.Severity = row.Severity;
                        errorCode.Symptoms = row.Symptoms;
                        errorCode.Guide = row.Guide;
                        context.SaveChanges();
                    }

                    bool exists = context.VehicleErrorCodes.Any(x =>
                        x.VehicleID == row.VehicleID && x.ErrorCodeID == errorCode.ErrorCodeID);

                    if (exists) { skipped++; continue; }

                    context.VehicleErrorCodes.Add(new VehicleErrorCode
                    {
                        VehicleID = row.VehicleID,
                        ErrorCodeID = errorCode.ErrorCodeID,
                        LoggedAt = row.LoggedAt ?? DateTime.Now,
                        Notes = row.Notes
                    });
                    context.SaveChanges();
                    createdVehicleErrorCodes++;
                }

                RefreshGrid();
                MessageBox.Show($"Import finished.\nNew ErrorCodes: {createdErrorCodes}\nNew VehicleErrorCodes: {createdVehicleErrorCodes}\nSkipped: {skipped}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"JSON import failed: {ex.Message}");
            }
        }

        private void btnExportJson_Click(object? sender, EventArgs e)
        {
            if (!TryGetContext(out var context)) return;

            using var sfd = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                Title = "Export error codes (JSON)",
                FileName = "vehicle_error_codes.json"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                var data = BuildExportQuery(context).ToList();
                var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(sfd.FileName, json, Encoding.UTF8);
                MessageBox.Show("JSON export completed.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"JSON export failed: {ex.Message}");
            }
        }

        private IQueryable<ErrorImportRow> BuildExportQuery(VehicleServiceContext context)
        {
            string term = txtSearch.Text.Trim().ToLowerInvariant();
            string moduleFilter = cmbModule.SelectedItem?.ToString() ?? "All";
            int vehicleId = GetSelectedVehicleId();

            var query = context.VehicleErrorCodes
                .Include(x => x.ErrorCode)
                .AsQueryable();

            if (vehicleId != 0) query = query.Where(x => x.VehicleID == vehicleId);
            if (moduleFilter != "All") query = query.Where(x => x.ErrorCode != null && x.ErrorCode.Module == moduleFilter);

            if (!string.IsNullOrWhiteSpace(term))
            {
                query = query.Where(x => x.ErrorCode != null &&
                    (x.ErrorCode.Code.ToLower().Contains(term) ||
                     x.ErrorCode.Title.ToLower().Contains(term)));
            }

            return query.Select(x => new ErrorImportRow
            {
                VehicleID = x.VehicleID,
                Code = x.ErrorCode != null ? x.ErrorCode.Code : "",
                Title = x.ErrorCode != null ? x.ErrorCode.Title : "",
                Module = x.ErrorCode != null ? x.ErrorCode.Module : "",
                Severity = x.ErrorCode != null ? x.ErrorCode.Severity : "",
                Symptoms = x.ErrorCode != null ? x.ErrorCode.Symptoms : null,
                Guide = x.ErrorCode != null ? x.ErrorCode.Guide : null,
                LoggedAt = x.LoggedAt,
                Notes = x.Notes
            });
        }

        private static bool ValidateImportRow(VehicleServiceContext context, ErrorImportRow row)
        {
            if (row.VehicleID <= 0) return false;
            if (string.IsNullOrWhiteSpace(row.Code)) return false;
            if (string.IsNullOrWhiteSpace(row.Title)) return false;
            if (string.IsNullOrWhiteSpace(row.Module)) return false;
            if (string.IsNullOrWhiteSpace(row.Severity) || !SeverityOk(row.Severity)) return false;
            return true;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            _context?.Dispose();
        }
    }
}
