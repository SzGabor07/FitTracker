using FitTracker.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FitTracker.Core.Entities;

namespace FitTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealLogController : ControllerBase
    {
        private readonly IMealLogService _mealLogService;

        public MealLogController(IMealLogService mealLogService)
        {
            _mealLogService = mealLogService;
        }

        [HttpPost("{dailyLogId}")]
        public async Task<IActionResult> CreateMealLog(Guid dailyLogId, [FromBody] MealLog mealLog)
        {
            if (mealLog == null) return BadRequest("Invalid meal log data.");
            try
            {
                var createdMealLog = await _mealLogService.CreateMealLogAsync(dailyLogId, mealLog);
                return CreatedAtAction(nameof(CreateMealLog), new { id = createdMealLog.Id }, createdMealLog);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while saving. Please check if the provided DailyLog ID exists!");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMealLogById(Guid id)
        {
            var mealLog = await _mealLogService.GetMealLogById(id);
            if (mealLog == null) return NotFound("The requested meal log was not found.");
            return Ok(mealLog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMealLog(Guid id, [FromBody] MealLog mealLog)
        {
            var updatedMealLog = await _mealLogService.UpdateMealLogAsync(id, mealLog);
            if (updatedMealLog == null) return NotFound("The meal log to be updated was not found.");
            return Ok(updatedMealLog);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMealLog(Guid id)
        {
            var deletedMealLog = await _mealLogService.DeleteMealLogAsync(id);
            if (!deletedMealLog) return NotFound("The meal log to be deleted was not found.");
            return NoContent();
        }

    }
}
