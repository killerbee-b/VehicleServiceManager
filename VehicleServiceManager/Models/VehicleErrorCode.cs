using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleServiceManager.Models
{
    public class VehicleErrorCode
    {
        public int VehicleErrorCodeID { get; set; }
        public int VehicleID { get; set; }
        public int ErrorCodeID { get; set; }

        public DateTime LoggedAt { get; set; }
        public string? Notes { get; set; }

        public Vehicle? Vehicle { get; set; }
        public ErrorCode? ErrorCode { get; set; }
    }
}
