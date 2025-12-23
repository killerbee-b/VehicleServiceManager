using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleServiceManager.Models
{
    public class ServicePart
    {
        public int ServicePartID { get; set; }
        public int ServiceOrderID { get; set; }
        public int PartID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        // Navigation properties (Connect to other entities)
        [ForeignKey("ServiceOrderID")]
        public virtual ServiceOrder ServiceOrder { get; set; }
        [ForeignKey("PartID")]
        public virtual Part Part { get; set; }

        //Calculate line total
        [NotMapped]
        public decimal LineTotal => Quantity * UnitPrice;
    }
}