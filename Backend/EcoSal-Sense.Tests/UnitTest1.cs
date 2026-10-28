using Xunit;
using EcoSal_Sense.Services;

namespace EcoSal_Sense.Tests
{
    public class SoilAnalysisServiceTests
    {
        [Fact]
        public void AnalyzeSoil_WhenHighSalinity_ReturnsCorrectBiocharRecommendation()
        {
            // Arrange ( ÃÂÌ“ «·»Ì«‰«  «· Ã—Ì»Ì…)
            double sampleMoisture = 18.5;
            double sampleTds = 2500.0; // „·ÊÕ… „ Ê”ÿ… ( ‰œ—Ã  Õ  <= 3000)

            var service = new SoilAnalysisService();

            // Act («” œ⁄«¡ œ«·… «·‹ Analyze «·›⁄·Ì…)
            var result = service.Analyze(sampleMoisture, sampleTds);

            // Assert («· Õﬁﬁ „‰ ’Õ… «·‰ «∆Ã Ê«· Ê’Ì« )
            Assert.NotNull(result);
            Assert.Contains("Moderate salt stress", result.SalinityStatus);
            Assert.True(result.BiocharDoseGramsPerKg > 0, "The recommended amount of biochar must be greater than zero.");
        }
    }
}