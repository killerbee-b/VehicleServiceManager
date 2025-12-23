using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VehicleServiceManager.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedDate { get; set; }

        //Helpful property for displaying full name
        public string FullName => $"{FirstName} {LastName}";

        // Navigation property
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
