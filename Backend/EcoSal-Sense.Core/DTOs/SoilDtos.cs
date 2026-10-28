using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSal_Sense.Core.DTOs
{
    public class SensorInputDto
    {
        public string DeviceId { get; set; } = string.Empty;
        public double SoilMoistureRaw { get; set; }
        public double TdsRaw { get; set; }
        public double Voltage { get; set; }
    }

    // نتيجة التحليل والتوصيات لعلاج التربة بالبيوتشار
    public class SoilAnalysisResultDto
    {
        public string SalinityStatus { get; set; } = string.Empty;
        public double BiocharDoseGramsPerKg { get; set; }
        public string Recommendation { get; set; } = string.Empty;
    }
}
