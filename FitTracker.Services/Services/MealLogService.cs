using AutoMapper;
using FitTracker.Core.DTOs;
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
        private readonly IMapper _mapper;

        public MealLogService(FitTrackerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MealLogResponseDto> CreateMealLogAsync(Guid dailyLogId, MealLogCreateDto newMealDto)
        {
            var mealLog = _mapper.Map<MealLog>(newMealDto);
            mealLog.DailyLogId = dailyLogId;
            await _context.AddAsync(mealLog);
            await _context.SaveChangesAsync();
            return _mapper.Map<MealLogResponseDto>(mealLog);
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

        public async Task<MealLogResponseDto?> GetMealLogById(Guid id)
        {
            var mealLog = await _context.MealLogs.FindAsync(id);
            return mealLog == null ? null : _mapper.Map<MealLogResponseDto>(mealLog);
        }

        public async Task<MealLogResponseDto?> UpdateMealLogAsync(Guid id, MealLogUpdateDto updatedMealDto)
        {
            var mealLog = await _context.MealLogs.FindAsync(id);
            if (mealLog == null)
                return null;
            _mapper.Map(updatedMealDto, mealLog);
            await _context.SaveChangesAsync();
            return _mapper.Map<MealLogResponseDto>(mealLog);
        }
    }
}

