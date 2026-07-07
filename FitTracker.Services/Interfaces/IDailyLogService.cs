using System;
using System.Collections.Generic;
using FitTracker.Core.Entities;
using System.Text;
using FitTracker.Core.DTOs;

namespace FitTracker.Services.Interfaces
{
    public interface IDailyLogService
    {
        Task<DailyLogResponseDto> CreateLogAsync(DailyLogCreateDto newLogDto);
        Task<IEnumerable<DailyLogResponseDto>> GetAllLogsAsync();
        Task<DailyLogResponseDto?> GetLogByIdAsync(Guid id);
        Task<DailyLogResponseDto?> UpdateLogAsync(Guid id, DailyLogUpdateDto updatedLogDto);
        Task<bool> DeleteLogAsync(Guid id);

        Task<bool> SeedTestDataAsync();
    }
}
