using System;
using System.Collections.Generic;
using FitTracker.Core.Entities;
using System.Text;

namespace FitTracker.Services.Interfaces
{
    public interface IDailyLogService
    {
        Task<DailyLog> CreateLogAsync(DailyLog newLog);
    }
}
