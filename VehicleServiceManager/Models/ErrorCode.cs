using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleServiceManager.Models
{
    public class ErrorCode
    {
        public int ErrorCodeID { get; set; }
        public string Code { get; set; } = "";
        public string Title { get; set; } = "";
        public string Module { get; set; } = "";
        public string Severity { get; set; } = "";
        public string? Symptoms { get; set; }
        public string? Guide { get; set; }
    }
}
