using System;
using System.Collections.Generic;
using FitTracker.Core.Entities;
using System.Text;

namespace FitTracker.Services.Interfaces
{
    public interface IDailyLogService
    {
        Task<DailyLog> CreateLogAsync(DailyLog newLog);
        Task<IEnumerable<DailyLog>> GetAllLogsAsync();
        Task<DailyLog?> GetLogByIdAsync(Guid id);
        Task<DailyLog?> UpdateLogAsync(Guid id, DailyLog updatedLog);
        Task<bool> DeleteLogAsync(Guid id);
    }
}
