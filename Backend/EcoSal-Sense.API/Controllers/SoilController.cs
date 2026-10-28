using EcoSal_Sense.Core.DTOs;
using EcoSal_Sense.Core.Interfaces;
using EcoSal_Sense.Core.Models;
using EcoSal_Sense.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcoSal_Sense.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoilController : ControllerBase
    {
        private readonly ISoilRepository _repository;
        private readonly SoilAnalysisService _analysisService;

        public SoilController(ISoilRepository repository, SoilAnalysisService analysisService)
        {
            _repository = repository;
            _analysisService = analysisService;
        }

        // 1. نقطة استقبال القراءات من الـ ESP32 (HTTP POST)
        [HttpPost("readings")]
        public async Task<IActionResult> PostReading([FromBody] SensorInputDto input)
        {
            // تحويل قيم الحساسات الخام إلى نسبة مئوية وقيم TDS دقيقة
            double moisturePercent = Math.Clamp((4095 - input.SoilMoistureRaw) / 4095.0 * 100, 0, 100);
            double tdsPpm = input.TdsRaw * 0.5;

            var reading = new SoilReading
            {
                DeviceId = input.DeviceId,
                MoisturePercentage = moisturePercent,
                TdsPpm = tdsPpm,
                Timestamp = DateTime.UtcNow
            };

            await _repository.AddReadingAsync(reading);

            return Ok(new { status = "Success", message = "The soil reading has been successfully received and saved.", data = reading });
        }

        // 2. نقطة لجلب أآخر قراءة مع التحليل وتوصيات البيوتشار (HTTP GET)
        [HttpGet("latest")]
        public async Task<IActionResult> GetLatestStatus()
        {
            var latest = await _repository.GetLatestReadingAsync();

            if (latest == null)
            {
                return NotFound(new { message = "No readings have been recorded yet." });
            }

            var analysis = _analysisService.Analyze(latest.MoisturePercentage, latest.TdsPpm);

            return Ok(new
            {
                Reading = latest,
                Analysis = analysis
            });
        }
    }
}
