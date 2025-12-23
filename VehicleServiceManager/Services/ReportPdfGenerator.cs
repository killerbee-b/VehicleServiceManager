using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace VehicleServiceManager.Services
{
    public static class ReportPdfGenerator
    {
        public static void GeneratePdf(List<Dictionary<string, object>> data,
                              List<string> columnNames,
                              List<string> columnHeaders,
                              string reportTitle,
                              string dateRange)
        {
            // Configure QuestPDF license
            QuestPDF.Settings.License = LicenseType.Community;

            // Generate filename
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string fileName = $"{reportTitle.Replace(" ", "_")}_{timestamp}.pdf";

            // Save to Documents/AUTO_B&T_Reports folder
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string reportsFolder = Path.Combine(documentsPath, "AUTO_B&T_Reports");

            // Create folder if it doesn't exist
            Directory.CreateDirectory(reportsFolder);

            string filePath = Path.Combine(reportsFolder, fileName);

            // Generate PDF
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4.Landscape());
                    page.Margin(30);
                    page.PageColor(Colors.White);

                    // Header
                    page.Header().Element(c => ComposeHeader(c, reportTitle, dateRange));

                    // Content
                    page.Content().Element(c => ComposeContent(c, data, columnNames, columnHeaders));

                    // Footer
                    page.Footer().AlignCenter().Text(text =>
                    {
                        text.DefaultTextStyle(TextStyle.Default.FontSize(8).FontColor(Colors.Grey.Medium));
                        text.Span("AUTO B&T Vehicle Services | ");
                        text.Span($"Printed on {DateTime.Now:dd-MMM-yyyy HH:mm}");
                        text.Span(" | Page ");
                        text.CurrentPageNumber();
                        text.Span(" of ");
                        text.TotalPages();
                    });
                });
            }).GeneratePdf(filePath);

            // Show success dialog with option to open folder
            var result = MessageBox.Show(
                $"✓ PDF Generated Successfully!\n\n" +
                $"Report: {reportTitle}\n" +
                $"Date Range: {dateRange}\n" +
                $"File: {fileName}\n\n" +
                $"Location:\n{reportsFolder}\n\n" +
                $"Would you like to open the folder?",
                "PDF Generated",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                // Open the folder and select the file
                Process.Start("explorer.exe", $"/select,\"{filePath}\"");
            }
            else
            {
                // Just open the PDF
                Process.Start(new ProcessStartInfo { FileName = filePath, UseShellExecute = true });
            }
        }

        private static void ComposeHeader(IContainer container, string reportTitle, string dateRange)
        {
            container.Column(column =>
            {
                column.Item().Background(Colors.Grey.Darken3).Padding(15).Row(row =>
                {
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text("AUTO B&T")
                            .FontSize(24)
                            .Bold()
                            .FontColor(Colors.White);
                        col.Item().Text(reportTitle)
                            .FontSize(14)
                            .FontColor(Colors.Grey.Lighten2);
                    });

                    row.ConstantItem(200).Column(col =>
                    {
                        col.Item().AlignRight().Text("Report Generated")
                            .FontSize(9)
                            .FontColor(Colors.Orange.Lighten2);
                        col.Item().AlignRight().Text(DateTime.Now.ToString("dd-MMMM-yyyy HH:mm"))
                            .FontSize(11)
                            .Bold()
                            .FontColor(Colors.White);
                        col.Item().AlignRight().Text($"Period: {dateRange}")
                            .FontSize(9)
                            .FontColor(Colors.Grey.Lighten2);
                    });
                });

                column.Item().PaddingVertical(5).LineHorizontal(2).LineColor(Colors.Orange.Medium);
            });
        }

        private static void ComposeContent(IContainer container, List<Dictionary<string, object>> data,
                                          List<string> columnNames, List<string> columnHeaders)
        {
            container.PaddingVertical(10).Column(column =>
            {
                if (data.Count == 0)
                {
                    column.Item().AlignCenter().PaddingVertical(50).Text("No data available")
                        .FontSize(14).Italic().FontColor(Colors.Grey.Medium);
                    return;
                }

                column.Item().Table(table =>
                {
                    // Define columns
                    table.ColumnsDefinition(columns =>
                    {
                        foreach (var colName in columnNames)
                        {
                            columns.RelativeColumn();
                        }
                    });

                    // Header row
                    table.Header(header =>
                    {
                        for (int i = 0; i < columnHeaders.Count; i++)
                        {
                            header.Cell()
                                .Background(Colors.Grey.Darken2)
                                .Padding(8)
                                .Text(columnHeaders[i])
                                .FontSize(10)
                                .Bold()
                                .FontColor(Colors.White);
                        }
                    });

                    // Data rows
                    foreach (var row in data)
                    {
                        foreach (var colName in columnNames)
                        {
                            var value = row.ContainsKey(colName) ? row[colName] : null;
                            var formattedValue = FormatValue(value, colName);

                            table.Cell()
                                .Border(0.5f)
                                .BorderColor(Colors.Grey.Lighten2)
                                .Padding(8)
                                .Text(formattedValue)
                                .FontSize(9);
                        }
                    }
                });
            });
        }

        private static string FormatValue(object value, string propertyName)
        {
            if (value == null) return "";

            string propLower = propertyName.ToLower();

            // Format currency
            if (propLower.Contains("revenue") || propLower.Contains("amount") ||
                propLower.Contains("cost") || propLower.Contains("price") ||
                propLower.Contains("spent") || propLower.Contains("value") ||
                propLower.Contains("balance"))
            {
                if (value is decimal dec) return dec.ToString("C2");
                if (value is double dbl) return dbl.ToString("C2");
                if (value is float flt) return flt.ToString("C2");
            }

            // Format dates
            if (value is DateTime dt)
            {
                return dt == DateTime.MinValue ? "N/A" : dt.ToString("dd-MMM-yyyy");
            }

            return value.ToString();
        }
    }
}
