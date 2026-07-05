using FitTracker.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FitTracker.Core.Entities;

namespace FitTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyLogsController : ControllerBase
    {
        private readonly IDailyLogService _dailyLogService;
        public DailyLogsController(IDailyLogService dailyLogService)
        {
            _dailyLogService = dailyLogService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLog([FromBody] DailyLog log)
        {
            if (log == null)
            {
                return BadRequest("Invalid log data.");
            }

            var createdLog = await _dailyLogService.CreateLogAsync(log);
            return CreatedAtAction(nameof(CreateLog), new { id = createdLog.Id }, createdLog);
        }
    }
}
