using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VehicleServiceManager.Helpers
{
    public static class CsvExportHelper
    {
        public static void ExportToCsv<T>(List<T> data, string defaultFileName, string entityName)
        {
            if (data == null || data.Count == 0)
            {
                MessageBox.Show($"No {entityName} data to export.", "Export Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                FileName = $"{defaultFileName}_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                Title = $"Export {entityName} to CSV"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var csv = GenerateCsv(data);
                    File.WriteAllText(sfd.FileName, csv, Encoding.UTF8);

                    var result = MessageBox.Show(
                        $"{data.Count} {entityName} records exported successfully!\n\n" +
                        $"File: {Path.GetFileName(sfd.FileName)}\n" +
                        $"Location: {Path.GetDirectoryName(sfd.FileName)}\n\n" +
                        "Would you like to open the folder?",
                        "Export Successful",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information);

                    if (result == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("explorer.exe",
                            Path.GetDirectoryName(sfd.FileName));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting to CSV:\n{ex.Message}",
                        "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static string GenerateCsv<T>(List<T> data)
        {
            var csv = new StringBuilder();
            var properties = typeof(T).GetProperties();

            // Header row
            csv.AppendLine(string.Join(",", properties.Select(p => EscapeCsvValue(p.Name))));

            // Data rows
            foreach (var item in data)
            {
                var values = properties.Select(p =>
                {
                    var value = p.GetValue(item);
                    return EscapeCsvValue(value?.ToString() ?? "");
                });
                csv.AppendLine(string.Join(",", values));
            }

            return csv.ToString();
        }

        private static string EscapeCsvValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n") || value.Contains("\r"))
            {
                return $"\"{value.Replace("\"", "\"\"")}\"";
            }

            return value;
        }
    }
}
