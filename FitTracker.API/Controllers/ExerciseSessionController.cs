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
            if (exercise == null) return BadRequest("Érvénytelen edzésadatok.");

            try
            {
                var createdExercise = await _exerciseService.AddExerciseToLogAsync(dailyLogId, exercise);
                return CreatedAtAction(nameof(AddExercise), new { id = createdExercise.Id }, createdExercise);
            }
            catch (Exception)
            {
            
                return StatusCode(500, "Hiba történt a mentés során. Ellenőrizd, hogy a megadott DailyLog ID létezik-e!");
            }
        }
    }
}