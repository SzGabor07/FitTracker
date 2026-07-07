using FitTracker.Core.Entities;
using FitTracker.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FitTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseSessionsController : ControllerBase
    {
        private readonly IExerciseSessionService _exerciseService;

        public ExerciseSessionsController(IExerciseSessionService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        
        [HttpPost("{dailyLogId}")]
        public async Task<IActionResult> AddExercise(Guid dailyLogId, [FromBody] ExerciseSession exercise)
        {
            if (exercise == null) return BadRequest("Invalid exercise data.");

            try
            {
                var createdExercise = await _exerciseService.AddExerciseToLogAsync(dailyLogId, exercise);
                return CreatedAtAction(nameof(AddExercise), new { id = createdExercise.Id }, createdExercise);
            }
            catch (Exception)
            {
            
                return StatusCode(500, "An error occurred while saving. Please check if the provided DailyLog ID exists!");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExercise(Guid id, [FromBody] ExerciseSession exercise) 
        {
            var updatedExercise = await _exerciseService.UpdateExerciseAsync(id, exercise);
            if (updatedExercise == null) return NotFound("The exercise to be updated was not found.");

            return Ok(updatedExercise);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercise(Guid id)
        {
            var isDeleted = await _exerciseService.DeleteExerciseAsync(id);
            if (!isDeleted) return NotFound("The exercise to be deleted was not found.");

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExercise(Guid id)
        {
            var exercise = await _exerciseService.GetExerciseByIdAsync(id);
            if (exercise == null) return NotFound("The requested exercise was not found.");

            return Ok(exercise);
        }
    }
}