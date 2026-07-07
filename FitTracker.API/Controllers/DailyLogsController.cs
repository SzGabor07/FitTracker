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

        [HttpGet]
        public async Task<IActionResult> GetAllLogs()
        {
            var logs = await _dailyLogService.GetAllLogsAsync();
            return Ok(logs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLogById(Guid id)
        {
            var log = await _dailyLogService.GetLogByIdAsync(id);
            if (log == null) return NotFound("The requested daily log was not found.");
            return Ok(log);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLog(Guid id, [FromBody] DailyLog log)
        {
            var updatedLog = await _dailyLogService.UpdateLogAsync(id, log);
            if (updatedLog == null) return NotFound("The daily log to be updated was not found.");
            return Ok(updatedLog);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLog(Guid id)
        {
            var isDeleted = await _dailyLogService.DeleteLogAsync(id);
            if (!isDeleted) return NotFound("The daily log to be deleted was not found.");
            return NoContent();
        }
    }
}
