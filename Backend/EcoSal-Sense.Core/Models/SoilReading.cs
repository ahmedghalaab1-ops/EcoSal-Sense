using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSal_Sense.Core.Models
{
    public class SoilReading
    {
        public int Id { get; set; }
        public string DeviceId { get; set; } = string.Empty;
        public double MoisturePercentage { get; set; }
        public double TdsPpm { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
