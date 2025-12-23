using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VehicleServiceManager.Models
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public int CustomerID { get; set; }
        public string VIN {  get; set; }
        public string Make {  get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string LicensePlate { get; set; }
        public int? Mileage { get; set; }

        // Navigation property
        public virtual Customer Customer { get; set; }
        public virtual ICollection<ServiceOrder> ServiceOrders { get; set; }

        //Helpful property for display
        public string DisplayName => $"{Year} {Make} {Model}";
    }
}
