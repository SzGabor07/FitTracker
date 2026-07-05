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

        public async Task<IEnumerable<DailyLog>> GetAllLogsAsync()
        {
            return await _context.DailyLogs
                .Include(d => d.Exercises)
                .Include(d => d.Meals)
                .ToListAsync();
        }

        public async Task<DailyLog?> GetLogByIdAsync(Guid id)
        {
            
            return await _context.DailyLogs.FindAsync(id);
        }

        
        public async Task<DailyLog?> UpdateLogAsync(Guid id, DailyLog updatedLog)
        {
            
            var existingLog = await _context.DailyLogs.FindAsync(id);
            if (existingLog == null) return null; 

            
            existingLog.Date = updatedLog.Date;
            existingLog.DayType = updatedLog.DayType;
            existingLog.BodyWeight = updatedLog.BodyWeight;

            
            await _context.SaveChangesAsync();
            return existingLog;
        }

        
        public async Task<bool> DeleteLogAsync(Guid id)
        {
            var log = await _context.DailyLogs.FindAsync(id);
            if (log == null) return false;

            
            _context.DailyLogs.Remove(log);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
