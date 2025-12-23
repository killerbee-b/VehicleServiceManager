using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleServiceManager.Models
{
    public class Part
    {
        public int PartID { get; set; }
        public string PartNumber { get; set; }
        public string PartName { get; set; }
        public string Supplier {  get; set; }
        public decimal UnitPrice { get; set; }
        public int StockQuantity { get; set; }
        public int? MinStockLevel { get; set; }

        //Check if stock is low
        public bool IsLowStock => MinStockLevel.HasValue && StockQuantity <= MinStockLevel.Value;
    }
}