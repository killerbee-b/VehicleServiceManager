using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleServiceManager.Models
{
    public class ServiceOrder
    {
        [Key]
        public int ServiceOrderID { get; set; }

        public int VehicleID { get; set; }

        [ForeignKey("VehicleID")]
        public Vehicle Vehicle { get; set; }

        public DateTime ServiceDate { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public decimal? LaborHours { get; set; }

        public decimal? LaborRate { get; set; }

        public decimal? PartsCost { get; set; }

        public decimal? Subtotal { get; set; }

        public decimal TaxRate { get; set; } = 0.18m;

        public decimal? TaxAmount { get; set; }

        public decimal? TotalCost { get; set; }

        public DateTime? CompletedDate { get; set; }

        public string Notes { get; set; }

        // Invoice fields
        public string InvoiceNumber { get; set; }

        public DateTime? InvoiceDate { get; set; }

        public string PaymentStatus { get; set; }

        public decimal AmountPaid { get; set; }

        [NotMapped]
        public decimal AmountDue => (TotalCost ?? 0) - AmountPaid;

        // Methods
        public void GenerateInvoiceNumber()
        {
            if (string.IsNullOrEmpty(InvoiceNumber))
            {
                InvoiceNumber = $"INV-{DateTime.Now.Year}-{ServiceOrderID:D4}";
                InvoiceDate = DateTime.Now;
            }
        }

        public void CalculateTotals()
        {
            decimal laborCost = (LaborHours ?? 0) * (LaborRate ?? 0);
            decimal partsCost = PartsCost ?? 0;

            Subtotal = laborCost + partsCost;
            TaxAmount = Subtotal * TaxRate;
            TotalCost = Subtotal + TaxAmount;
        }

        public void UpdatePaymentStatus()
        {
            if (AmountPaid == 0)
            {
                PaymentStatus = "Unpaid";
            }
            else if (AmountPaid >= (TotalCost ?? 0))
            {
                PaymentStatus = "Paid";
            }
            else
            {
                PaymentStatus = "Partial";
            }
        }
    }
}