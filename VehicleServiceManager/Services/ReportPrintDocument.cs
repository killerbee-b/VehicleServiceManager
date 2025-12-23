using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;

namespace VehicleServiceManager.Services
{
    public class ReportPrintDocument : PrintDocument
    {
        private List<Dictionary<string, object>> data;
        private List<string> columnNames;
        private List<string> columnHeaders;
        private string reportTitle;
        private string dateRange;
        private int currentPage = 0;
        private int currentRow = 0;

        public ReportPrintDocument(List<Dictionary<string, object>> data,
                                  List<string> columnNames,
                                  List<string> columnHeaders,
                                  string reportTitle,
                                  string dateRange)
        {
            this.data = data;
            this.columnNames = columnNames;
            this.columnHeaders = columnHeaders;
            this.reportTitle = reportTitle;
            this.dateRange = dateRange;

            this.DefaultPageSettings.Landscape = true;
            this.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);
        }

        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            base.OnPrintPage(e);

            float yPos = e.MarginBounds.Top;
            float leftMargin = e.MarginBounds.Left;
            Font headerFont = new Font("Arial", 18, FontStyle.Bold);
            Font subHeaderFont = new Font("Arial", 10);
            Font tableHeaderFont = new Font("Arial", 9, FontStyle.Bold);
            Font tableFont = new Font("Arial", 8);

            // Header
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(45, 45, 48)),
                leftMargin, yPos, e.MarginBounds.Width, 60);
            e.Graphics.DrawString("AUTO B&T", headerFont, Brushes.White, leftMargin + 10, yPos + 10);
            e.Graphics.DrawString(reportTitle, subHeaderFont, Brushes.LightGray, leftMargin + 10, yPos + 35);
            e.Graphics.DrawString($"Period: {dateRange}", subHeaderFont, Brushes.LightGray,
                e.MarginBounds.Right - 200, yPos + 35);

            yPos += 80;

            // Calculate column widths
            float columnWidth = e.MarginBounds.Width / columnNames.Count;

            // Table header
            float xPos = leftMargin;
            foreach (var header in columnHeaders)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(70, 70, 70)),
                    xPos, yPos, columnWidth, 25);
                e.Graphics.DrawString(header, tableHeaderFont, Brushes.White, xPos + 5, yPos + 5);
                xPos += columnWidth;
            }

            yPos += 30;

            // Table rows
            int rowsPerPage = (int)((e.MarginBounds.Bottom - yPos) / 25);
            int rowCount = 0;

            while (currentRow < data.Count && rowCount < rowsPerPage)
            {
                var row = data[currentRow];
                xPos = leftMargin;

                foreach (var colName in columnNames)
                {
                    var value = row.ContainsKey(colName) ? row[colName] : null;
                    string formattedValue = FormatValue(value, colName);

                    e.Graphics.DrawRectangle(Pens.LightGray, xPos, yPos, columnWidth, 25);
                    e.Graphics.DrawString(formattedValue, tableFont, Brushes.Black, xPos + 5, yPos + 5);
                    xPos += columnWidth;
                }

                yPos += 25;
                currentRow++;
                rowCount++;
            }

            // Footer
            currentPage++;
            string footer = $"AUTO B&T Vehicle Services | Printed on {DateTime.Now:dd-MMM-yyyy HH:mm} | Page {currentPage}";
            e.Graphics.DrawString(footer, new Font("Arial", 7), Brushes.Gray,
                new PointF(leftMargin, e.MarginBounds.Bottom + 10));

            // Check if more pages needed
            e.HasMorePages = (currentRow < data.Count);
        }

        private string FormatValue(object value, string propertyName)
        {
            if (value == null) return "";

            string propLower = propertyName.ToLower();

            // Currency
            if (propLower.Contains("revenue") || propLower.Contains("amount") ||
                propLower.Contains("cost") || propLower.Contains("price") ||
                propLower.Contains("spent") || propLower.Contains("value") ||
                propLower.Contains("balance"))
            {
                if (value is decimal dec) return dec.ToString("C2");
                if (value is double dbl) return dbl.ToString("C2");
                if (value is float flt) return flt.ToString("C2");
            }

            // Dates
            if (value is DateTime dt)
            {
                return dt == DateTime.MinValue ? "N/A" : dt.ToString("dd-MMM-yyyy");
            }

            return value.ToString();
        }
    }
}
