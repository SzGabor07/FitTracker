using System;
using System.Collections.Generic;
using System.Text;
using FitTracker.Core.Entities;
using FitTracker.Core.DTOs;

namespace FitTracker.Services.Interfaces
{
    public interface IExerciseSessionService
    {
        Task<ExerciseSessionResponseDto> AddExerciseToLogAsync(Guid dailyLogId, ExerciseSessionCreateDto newExerciseDto);
        Task<ExerciseSessionResponseDto> GetExerciseByIdAsync(Guid id);
        Task<ExerciseSessionResponseDto?> UpdateExerciseAsync(Guid id, ExerciseSessionUpdateDto updatedDto);
        Task<bool> DeleteExerciseAsync(Guid id);
        
    }
}
