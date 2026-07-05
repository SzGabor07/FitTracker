using System;
using System.Collections.Generic;
using System.Text;
using FitTracker.Core.Entities;
using FitTracker.Data;
using FitTracker.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitTracker.Services.Services
{
    public class DailyLogService : IDailyLogService
    {
        private readonly FitTrackerDbContext _context;
        public DailyLogService(FitTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<DailyLog> CreateLogAsync(DailyLog newLog)
        {
            await _context.DailyLogs.AddAsync(newLog);
            await _context.SaveChangesAsync();
            return newLog;
        }
        
    }
}
