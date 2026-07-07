using System;
using System.Collections.Generic;
using System.Text;
using FitTracker.Core.DTOs;
using FitTracker.Core.Entities;

namespace FitTracker.Services.Interfaces
{
    public interface IMealLogService
    {
        Task<MealLogResponseDto> CreateMealLogAsync(Guid dailyLogId, MealLogCreateDto newMealDto);
        Task<MealLogResponseDto?> GetMealLogById(Guid id);
        Task<MealLogResponseDto?> UpdateMealLogAsync(Guid id, MealLogUpdateDto updatedMealDto);
        Task<bool> DeleteMealLogAsync(Guid id);
    }
}
