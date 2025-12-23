using System;
using System.Drawing;
using System.Drawing.Printing;
using VehicleServiceManager.Models;

namespace VehicleServiceManager.Services
{
    public class InvoicePrintDocument : PrintDocument
    {
        private ServiceOrder _serviceOrder;
        private Font _titleFont;
        private Font _headerFont;
        private Font _boldFont;
        private Font _normalFont;
        private Font _smallFont;

        public InvoicePrintDocument(ServiceOrder serviceOrder)
        {
            _serviceOrder = serviceOrder;

            // Initialize fonts
            _titleFont = new Font("Segoe UI", 20, FontStyle.Bold);
            _headerFont = new Font("Segoe UI", 14, FontStyle.Bold);
            _boldFont = new Font("Segoe UI", 10, FontStyle.Bold);
            _normalFont = new Font("Segoe UI", 10, FontStyle.Regular);
            _smallFont = new Font("Segoe UI", 8, FontStyle.Regular);

            // Set document name
            DocumentName = $"{_serviceOrder.InvoiceNumber}_Invoice";
        }

        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            base.OnPrintPage(e);

            Graphics g = e.Graphics;
            float y = 50; // Starting Y position
            float leftMargin = 50;
            float rightMargin = e.PageBounds.Width - 50;
            float pageWidth = rightMargin - leftMargin;

            // --- HEADER SECTION ---
            // Dark background rectangle
            g.FillRectangle(new SolidBrush(Color.FromArgb(45, 45, 48)),
                leftMargin, y, pageWidth, 80);

            // Company name
            g.DrawString("AUTO B&T", _titleFont, Brushes.White, leftMargin + 20, y + 15);
            g.DrawString("Vehicle Service Invoice", _normalFont, Brushes.LightGray, leftMargin + 20, y + 50);

            // Invoice number and date (right side)
            string invoiceDate = (_serviceOrder.InvoiceDate ?? DateTime.Now).ToString("dd MMMM yyyy");
            SizeF dateSize = g.MeasureString(invoiceDate, _boldFont);
            g.DrawString("Invoice Date", _smallFont, Brushes.LightGray,
                rightMargin - dateSize.Width - 20, y + 20);
            g.DrawString(invoiceDate, _boldFont, Brushes.Orange,
                rightMargin - dateSize.Width - 20, y + 35);

            y += 100;

            // --- INVOICE DETAILS AND PAYMENT STATUS ---
            // Left: Invoice details
            g.DrawString("INVOICE DETAILS", _boldFont, Brushes.DarkGray, leftMargin, y);
            y += 25;
            g.DrawString($"Invoice Number: {_serviceOrder.InvoiceNumber}", _normalFont, Brushes.Black, leftMargin, y);
            y += 20;
            g.DrawString($"Service Date: {_serviceOrder.ServiceDate:dd-MMM-yyyy}", _normalFont, Brushes.Black, leftMargin, y);

            // Right: Payment status
            float statusX = rightMargin - 200;
            float statusY = y - 45;

            Color statusColor = _serviceOrder.PaymentStatus switch
            {
                "Paid" => Color.FromArgb(27, 94, 32),
                "Partial" => Color.FromArgb(230, 81, 0),
                _ => Color.FromArgb(183, 28, 28)
            };

            Color statusBgColor = _serviceOrder.PaymentStatus switch
            {
                "Paid" => Color.FromArgb(200, 230, 201),
                "Partial" => Color.FromArgb(255, 224, 178),
                _ => Color.FromArgb(255, 235, 238)
            };

            // Status box
            g.FillRectangle(new SolidBrush(statusBgColor), statusX, statusY, 200, 60);
            g.DrawRectangle(new Pen(statusColor, 2), statusX, statusY, 200, 60);

            // Center text in box
            string status = (_serviceOrder.PaymentStatus ?? "UNPAID").ToUpper();
            SizeF statusSize = g.MeasureString(status, _headerFont);
            g.DrawString(status, _headerFont, new SolidBrush(statusColor),
                statusX + (200 - statusSize.Width) / 2, statusY + 10);

            string amountDue = $"Amount Due: €{_serviceOrder.AmountDue:F2}";
            SizeF amountSize = g.MeasureString(amountDue, _boldFont);
            g.DrawString(amountDue, _boldFont, new SolidBrush(statusColor),
                statusX + (200 - amountSize.Width) / 2, statusY + 35);

            y += 40;

            // --- SEPARATOR LINE ---
            g.DrawLine(new Pen(Color.LightGray, 1), leftMargin, y, rightMargin, y);
            y += 20;

            // --- CUSTOMER AND VEHICLE INFO ---
            float columnWidth = pageWidth / 2 - 20;

            // Customer info (left)
            g.DrawString("BILL TO", _boldFont, Brushes.DarkGray, leftMargin, y);
            y += 25;
            g.DrawString(_serviceOrder.Vehicle.Customer.FullName, _headerFont, Brushes.Black, leftMargin, y);
            y += 25;
            g.DrawString(_serviceOrder.Vehicle.Customer.Phone, _normalFont, Brushes.Black, leftMargin, y);
            y += 20;
            g.DrawString(_serviceOrder.Vehicle.Customer.Email ?? "N/A", _normalFont, Brushes.Black, leftMargin, y);
            y += 20;
            g.DrawString(_serviceOrder.Vehicle.Customer.Address ?? "N/A", _normalFont, Brushes.Black, leftMargin, y);

            // Vehicle info (right)
            float vehicleX = leftMargin + columnWidth + 40;
            float vehicleY = y - 90;
            g.DrawString("VEHICLE", _boldFont, Brushes.DarkGray, vehicleX, vehicleY);
            vehicleY += 25;
            g.DrawString($"{_serviceOrder.Vehicle.Year} {_serviceOrder.Vehicle.Make} {_serviceOrder.Vehicle.Model}",
                _headerFont, Brushes.Black, vehicleX, vehicleY);
            vehicleY += 25;
            g.DrawString($"VIN: {_serviceOrder.Vehicle.VIN}", _normalFont, Brushes.Black, vehicleX, vehicleY);
            vehicleY += 20;
            g.DrawString($"License: {_serviceOrder.Vehicle.LicensePlate}", _normalFont, Brushes.Black, vehicleX, vehicleY);

            y += 40;

            // --- SEPARATOR LINE ---
            g.DrawLine(new Pen(Color.LightGray, 1), leftMargin, y, rightMargin, y);
            y += 20;

            // --- SERVICE DESCRIPTION ---
            g.DrawString("SERVICE DESCRIPTION", _boldFont, Brushes.DarkGray, leftMargin, y);
            y += 25;

            // Draw description box
            RectangleF descBox = new RectangleF(leftMargin, y, pageWidth, 60);
            g.FillRectangle(Brushes.WhiteSmoke, descBox);
            g.DrawRectangle(Pens.LightGray, leftMargin, y, pageWidth, 60);

            // Draw description text with word wrap
            string description = _serviceOrder.Description ?? "No description provided.";
            g.DrawString(description, _normalFont, Brushes.Black,
                new RectangleF(leftMargin + 10, y + 10, pageWidth - 20, 40));

            y += 80;

            // --- SEPARATOR LINE ---
            g.DrawLine(new Pen(Color.LightGray, 1), leftMargin, y, rightMargin, y);
            y += 20;

            // --- COST BREAKDOWN ---
            g.DrawString("COST BREAKDOWN", _boldFont, Brushes.DarkGray, leftMargin, y);
            y += 30;

            // Labor
            decimal laborHours = _serviceOrder.LaborHours ?? 0;
            decimal laborRate = _serviceOrder.LaborRate ?? 0;
            decimal laborCost = laborHours * laborRate;

            g.DrawString("Labor", _boldFont, Brushes.Black, leftMargin, y);
            g.DrawString($"{laborHours:F1}h @ €{laborRate:F2}/h", _smallFont, Brushes.Gray, leftMargin, y + 18);
            g.DrawString($"€{laborCost:F2}", _normalFont, Brushes.Black, rightMargin - 80, y);
            y += 40;

            // Parts
            g.DrawString("Parts", _boldFont, Brushes.Black, leftMargin, y);
            g.DrawString($"€{(_serviceOrder.PartsCost ?? 0):F2}", _normalFont, Brushes.Black, rightMargin - 80, y);
            y += 30;

            // Separator before totals
            g.DrawLine(new Pen(Color.LightGray, 1), rightMargin - 250, y, rightMargin, y);
            y += 20;

            // Totals (right-aligned)
            float totalLabelX = rightMargin - 200;
            float totalValueX = rightMargin - 80;

            // Subtotal
            g.DrawString("Subtotal:", _boldFont, Brushes.Black, totalLabelX, y);
            g.DrawString($"€{(_serviceOrder.Subtotal ?? 0):F2}", _normalFont, Brushes.Black, totalValueX, y);
            y += 25;

            // Tax
            g.DrawString($"Tax ({(_serviceOrder.TaxRate * 100):F0}%):", _boldFont, Brushes.Black, totalLabelX, y);
            g.DrawString($"€{(_serviceOrder.TaxAmount ?? 0):F2}", _normalFont, Brushes.Black, totalValueX, y);
            y += 30;

            // Total separator
            g.DrawLine(new Pen(Color.DarkGray, 2), totalLabelX, y, rightMargin, y);
            y += 15;

            // TOTAL (highlighted)
            RectangleF totalBox = new RectangleF(totalLabelX - 10, y, 270, 40);
            g.FillRectangle(new SolidBrush(Color.FromArgb(45, 45, 48)), totalBox);

            g.DrawString("TOTAL:", _headerFont, Brushes.White, totalLabelX, y + 8);
            g.DrawString($"€{(_serviceOrder.TotalCost ?? 0):F2}", _headerFont, Brushes.Orange, totalValueX - 20, y + 8);

            y += 60;

            // --- FOOTER ---
            y = e.PageBounds.Height - 80;
            g.DrawLine(new Pen(Color.LightGray, 1), leftMargin, y, rightMargin, y);
            y += 15;

            string footer = "AUTO B&T Vehicle Services  |  Thank you for your business!";
            SizeF footerSize = g.MeasureString(footer, _normalFont);
            g.DrawString(footer, _normalFont, Brushes.Gray,
                leftMargin + (pageWidth - footerSize.Width) / 2, y);

            y += 20;
            string timestamp = $"Printed on {DateTime.Now:dd/MM/yyyy HH:mm}";
            SizeF timestampSize = g.MeasureString(timestamp, _smallFont);
            g.DrawString(timestamp, _smallFont, Brushes.LightGray,
                leftMargin + (pageWidth - timestampSize.Width) / 2, y);

            // No more pages
            e.HasMorePages = false;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _titleFont?.Dispose();
                _headerFont?.Dispose();
                _boldFont?.Dispose();
                _normalFont?.Dispose();
                _smallFont?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
