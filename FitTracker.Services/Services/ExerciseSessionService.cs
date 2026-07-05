using FitTracker.Core.Entities;
using FitTracker.Services.Interfaces;
using FitTracker.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitTracker.Services.Services
{
    public class ExerciseSessionService : IExerciseSessionService
    {
        private readonly FitTrackerDbContext _context;
        public ExerciseSessionService(FitTrackerDbContext context)
        {
            _context = context;
        }
        public async Task<ExerciseSession> AddExerciseToLogAsync(Guid dailyLogId, ExerciseSession exercise)
        {
            exercise.DailyLogId = dailyLogId;
            await _context.ExerciseSessions.AddAsync(exercise);
            await _context.SaveChangesAsync();

            return exercise;
        }
    }
}
