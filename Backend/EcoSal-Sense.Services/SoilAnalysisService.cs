using EcoSal_Sense.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSal_Sense.Services
{
    public class SoilAnalysisService
    {
        public SoilAnalysisResultDto Analyze(double moisture, double tdsPpm)
        {
            var result = new SoilAnalysisResultDto();

            // 1. تقييم مستوى ملوحة التربة بناءً على قراءة الـ TDS (PPM)
            if (tdsPpm < 1000)
            {
                result.SalinityStatus = "Natural salinity / safe for agriculture";
            }
            else if (tdsPpm <= 3000)
            {
                result.SalinityStatus = "Moderate salt stress (requires corrective intervention)";
            }
            else
            {
                result.SalinityStatus = "Very high salinity (negative impact on crop growth)";
            }

            // 2. حساب جرعة البيوتشار المقترحة (Biochar Dose) بالجرام لكل كيلوجرام تربة
            if (tdsPpm > 1000)
            {
                // معادلة تقريبية مبنية على معايير الهندسة الزراعية لمعالجة الملوحة بالبيوتشار
                result.BiocharDoseGramsPerKg = Math.Round((tdsPpm - 1000) * 0.0035, 2);
                result.Recommendation = $"It is recommended to add {result.BiocharDoseGramsPerKg} grams of biochar per kilogram of soil to absorb excess salts, reduce electrical conductivity, and improve moisture retention.";
            }
            else
            {
                result.BiocharDoseGramsPerKg = 0;
                result.Recommendation = "The soil is in good condition and does not require any biochar additions at this time.";
            }

            return result;
        }
    }
}
