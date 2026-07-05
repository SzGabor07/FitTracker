using System;
using System.Collections.Generic;
using System.Text;
using FitTracker.Core.Entities;

namespace FitTracker.Services.Interfaces
{
    public interface IExerciseSessionService
    {
        Task<ExerciseSession> AddExerciseToLogAsync(Guid dailyLogId, ExerciseSession exercise);
        
    }
}
