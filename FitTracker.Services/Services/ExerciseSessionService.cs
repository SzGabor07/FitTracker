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

        public async Task<ExerciseSession?> UpdateExerciseAsync(Guid id, ExerciseSession updatedExercise)
        {
            var existingExercise = await _context.ExerciseSessions.FindAsync(id);
            if (existingExercise == null) return null;

            
            existingExercise.ExerciseName = updatedExercise.ExerciseName;
            existingExercise.Sets = updatedExercise.Sets;
            existingExercise.Reps = updatedExercise.Reps;
            existingExercise.Weight = updatedExercise.Weight;

            await _context.SaveChangesAsync();
            return existingExercise;
        }

        public async Task<bool> DeleteExerciseAsync(Guid id)
        {
            var existingExercise = await _context.ExerciseSessions.FindAsync(id);
            if (existingExercise == null) return false;

            _context.ExerciseSessions.Remove(existingExercise);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ExerciseSession?> GetExerciseByIdAsync(Guid id)
        {
            return await _context.ExerciseSessions.FindAsync(id);
        }
    }
}
