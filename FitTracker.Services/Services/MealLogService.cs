using FitTracker.Core.Entities;
using FitTracker.Data;
using FitTracker.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitTracker.Services.Services
{
    public class MealLogService : IMealLogService
    {
        private readonly FitTrackerDbContext _context;

        public MealLogService(FitTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<MealLog> CreateMealLogAsync(Guid dailyLogId, MealLog mealLog)
        {
            mealLog.DailyLogId = dailyLogId;
            await _context.AddAsync(mealLog);
            await _context.SaveChangesAsync();
            return mealLog;
        }

        public async Task<bool> DeleteMealLogAsync(Guid id)
        {
            var mealLog = await _context.MealLogs.FindAsync(id);
            if (mealLog == null)
                return false;

            _context.MealLogs.Remove(mealLog);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<MealLog?> GetMealLogById(Guid id)
        {
            return await _context.MealLogs.FindAsync(id);
        }

        public async Task<MealLog?> UpdateMealLogAsync(Guid id, MealLog updatedMealLog)
        {
            var mealLog = await _context.MealLogs.FindAsync(id);
            if (mealLog == null)
                return null;
            mealLog.Protein = updatedMealLog.Protein;
            mealLog.Carbs = updatedMealLog.Carbs;
            mealLog.Fats = updatedMealLog.Fats;
            mealLog.Calories = updatedMealLog.Calories;
            mealLog.MealName = updatedMealLog.MealName;

            await _context.SaveChangesAsync();
            return mealLog;
        
        }
    }
}
