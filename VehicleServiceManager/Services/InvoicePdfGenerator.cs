using System;
using System.IO;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using VehicleServiceManager.Models;

namespace VehicleServiceManager.Services
{
    public class InvoicePdfGenerator
    {
        public static string GeneratePdf(ServiceOrder serviceOrder)
        {
            // Create invoices directory in Documents folder
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string invoicesFolder = Path.Combine(documentsPath, "AUTO_B&T_Invoices");

            if (!Directory.Exists(invoicesFolder))
            {
                Directory.CreateDirectory(invoicesFolder);
            }

            // Generate filename
            string fileName = $"{serviceOrder.InvoiceNumber}_{serviceOrder.Vehicle.Customer.LastName}.pdf";
            string filePath = Path.Combine(invoicesFolder, fileName);

            // Generate PDF
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(40);
                    page.DefaultTextStyle(x => x.FontSize(10).FontFamily("Segoe UI"));
                    page.Header().Element(ComposeHeader);
                    page.Content().Element(container => ComposeContent(container, serviceOrder));
                    page.Footer().Element(ComposeFooter);
                });
            })
            .GeneratePdf(filePath);

            return filePath;
        }

        private static void ComposeHeader(IContainer container)
        {
            container.Column(column =>
            {
                // Company header
                column.Item().Background(Colors.Grey.Darken4).Padding(15).Row(row =>
                {
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text("AUTO B&T").FontSize(24).Bold().FontColor(Colors.White);
                        col.Item().Text("Vehicle Service Invoice").FontSize(12).FontColor(Colors.Grey.Lighten2);
                    });

                    row.RelativeItem().AlignRight().Column(col =>
                    {
                        col.Item().AlignRight().Text("Invoice Date").FontSize(9).FontColor(Colors.Grey.Lighten2);
                        col.Item().AlignRight().Text(DateTime.Now.ToString("dd MMMM yyyy")).FontSize(11).Bold().FontColor(Colors.Amber.Accent2);
                    });
                });

                column.Item().PaddingVertical(5);
            });
        }
        private static void ComposeContent(IContainer container, ServiceOrder serviceOrder)
        {
            container.Column(column =>
            {
                column.Spacing(15);

                // Invoice Number and Payment Status
                column.Item().Row(row =>
                {
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text("INVOICE DETAILS").Bold().FontSize(11).FontColor(Colors.Grey.Darken2);
                        col.Item().PaddingTop(5).Text(text =>
                        {
                            text.Span("Invoice Number: ").SemiBold();
                            text.Span(serviceOrder.InvoiceNumber).Bold().FontColor(Colors.Amber.Darken2);
                        });
                        col.Item().Text(text =>
                        {
                            text.Span("Service Date: ").SemiBold();
                            text.Span(serviceOrder.ServiceDate.ToString("dd-MMM-yyyy"));
                        });
                    });

                    row.RelativeItem().AlignRight().Column(col =>
                    {
                        var statusColor = serviceOrder.PaymentStatus switch
                        {
                            "Paid" => Colors.Green.Darken2,
                            "Partial" => Colors.Orange.Darken2,
                            _ => Colors.Red.Darken2
                        };

                        col.Item().AlignRight().Background(Colors.Grey.Lighten3).Padding(10).Column(statusCol =>
                        {
                            statusCol.Item().AlignCenter().Text(serviceOrder.PaymentStatus?.ToUpper() ?? "UNPAID")
                                .Bold().FontSize(12).FontColor(statusColor);
                            statusCol.Item().AlignCenter().PaddingTop(5).Text($"Amount Due: €{serviceOrder.AmountDue:F2}")
                                .Bold().FontColor(statusColor);
                        });
                    });
                });

                // Separator
                column.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten2);

                // Customer and Vehicle Information
                column.Item().Row(row =>
                {
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text("BILL TO").Bold().FontSize(11).FontColor(Colors.Grey.Darken2);
                        col.Item().PaddingTop(5).Text(serviceOrder.Vehicle.Customer.FullName).Bold().FontSize(12);
                        col.Item().Text(serviceOrder.Vehicle.Customer.Phone);
                        col.Item().Text(serviceOrder.Vehicle.Customer.Email ?? "N/A");
                        col.Item().Text(serviceOrder.Vehicle.Customer.Address ?? "N/A");
                    });

                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text("VEHICLE").Bold().FontSize(11).FontColor(Colors.Grey.Darken2);
                        col.Item().PaddingTop(5).Text($"{serviceOrder.Vehicle.Year} {serviceOrder.Vehicle.Make} {serviceOrder.Vehicle.Model}")
                            .Bold().FontSize(12);
                        col.Item().Text($"VIN: {serviceOrder.Vehicle.VIN}");
                        col.Item().Text($"License: {serviceOrder.Vehicle.LicensePlate}");
                    });
                });

                // Separator
                column.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten2);

                // Service Description
                column.Item().Column(col =>
                {
                    col.Item().Text("SERVICE DESCRIPTION").Bold().FontSize(11).FontColor(Colors.Grey.Darken2);
                    col.Item().PaddingTop(5).Background(Colors.Grey.Lighten4).Padding(10)
                        .Text(serviceOrder.Description ?? "No description provided.");
                });

                // Separator
                column.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten2);

                // Cost Breakdown
                column.Item().Column(col =>
                {
                    col.Item().Text("COST BREAKDOWN").Bold().FontSize(11).FontColor(Colors.Grey.Darken2);
                    col.Item().PaddingTop(10);

                    // Labor
                    col.Item().Row(row =>
                    {
                        row.RelativeItem().Text(text =>
                        {
                            text.Span("Labor").SemiBold();
                            text.Span($"\n{(serviceOrder.LaborHours ?? 0):F1}h @ €{(serviceOrder.LaborRate ?? 0):F2}/h")
                                .FontSize(8).FontColor(Colors.Grey.Darken1);
                        });
                        row.ConstantItem(100).AlignRight().Text($"€{((serviceOrder.LaborHours ?? 0) * (serviceOrder.LaborRate ?? 0)):F2}");
                    });

                    col.Item().PaddingTop(5);

                    // Parts
                    col.Item().Row(row =>
                    {
                        row.RelativeItem().Text("Parts").SemiBold();
                        row.ConstantItem(100).AlignRight().Text($"€{(serviceOrder.PartsCost ?? 0):F2}");
                    });

                    col.Item().PaddingTop(10).LineHorizontal(1).LineColor(Colors.Grey.Lighten2);
                });

                // Totals
                column.Item().PaddingTop(10).AlignRight().Column(col =>
                {
                    col.Item().Row(row =>
                    {
                        row.ConstantItem(150).Text("Subtotal:").SemiBold();
                        row.ConstantItem(100).AlignRight().Text($"€{(serviceOrder.Subtotal ?? 0):F2}");
                    });

                    col.Item().PaddingTop(5).Row(row =>
                    {
                        row.ConstantItem(150).Text($"Tax ({(serviceOrder.TaxRate * 100):F0}%):").SemiBold();
                        row.ConstantItem(100).AlignRight().Text($"€{(serviceOrder.TaxAmount ?? 0):F2}");
                    });

                    col.Item().PaddingTop(10).LineHorizontal(2).LineColor(Colors.Grey.Darken2);

                    col.Item().PaddingTop(10).Background(Colors.Grey.Darken3).Padding(10).Row(row =>
                    {
                        row.ConstantItem(150).Text("TOTAL:").Bold().FontSize(12).FontColor(Colors.White);
                        row.ConstantItem(100).AlignRight().Text($"€{(serviceOrder.TotalCost ?? 0):F2}")
                            .Bold().FontSize(14).FontColor(Colors.Amber.Accent2);
                    });
                });
            });
        }

        private static void ComposeFooter(IContainer container)
        {
            container.AlignCenter().Column(column =>
            {
                column.Item().PaddingTop(10).LineHorizontal(1).LineColor(Colors.Grey.Lighten2);
                column.Item().PaddingTop(5).Text(text =>
                {
                    text.Span("AUTO B&T Vehicle Services").SemiBold().FontSize(9);
                    text.Span(" | ").FontSize(9);
                    text.Span("Thank you for your business!").FontSize(9).FontColor(Colors.Grey.Darken1);
                });
                column.Item().Text($"Generated on {DateTime.Now:dd/MM/yyyy HH:mm}").FontSize(8).FontColor(Colors.Grey.Medium);
            });
        }
    }
}
