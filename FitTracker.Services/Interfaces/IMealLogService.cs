using System;
using System.Collections.Generic;
using System.Text;
using FitTracker.Core.Entities;

namespace FitTracker.Services.Interfaces
{
    public interface IMealLogService
    {
        Task<MealLog> CreateMealLogAsync(Guid dailyLogId, MealLog mealLog);
        Task<MealLog?> GetMealLogById(Guid id);
        Task<MealLog?> UpdateMealLogAsync(Guid id, MealLog updatedMealLog);
        Task<bool> DeleteMealLogAsync(Guid id);
    }
}
