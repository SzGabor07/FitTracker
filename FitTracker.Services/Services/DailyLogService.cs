using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FitTracker.Core.DTOs;
using FitTracker.Core.Entities;
using FitTracker.Core.Enums;
using FitTracker.Data;
using FitTracker.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitTracker.Services.Services
{
    public class DailyLogService : IDailyLogService
    {
        private readonly FitTrackerDbContext _context;
        private readonly IMapper _mapper;
        public DailyLogService(FitTrackerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DailyLogResponseDto> CreateLogAsync(DailyLogCreateDto newLogDto)
        {
            var newLog = _mapper.Map<DailyLog>(newLogDto);
            await _context.DailyLogs.AddAsync(newLog);
            await _context.SaveChangesAsync();
            return _mapper.Map<DailyLogResponseDto>(newLog);
        }

        public async Task<IEnumerable<DailyLogResponseDto>> GetAllLogsAsync()
        {
            var dailyLogs = await _context.DailyLogs
                .Include(d => d.Exercises)
                .Include(d => d.Meals)
                .ToListAsync();
            return _mapper.Map<IEnumerable<DailyLogResponseDto>>(dailyLogs);
        }
        

        public async Task<DailyLogResponseDto?> GetLogByIdAsync(Guid id)
        {
            var dailyLog = await _context.DailyLogs.FindAsync(id);
            return dailyLog == null ? null : _mapper.Map<DailyLogResponseDto>(dailyLog);
        }

        
        public async Task<DailyLogResponseDto?> UpdateLogAsync(Guid id, DailyLogUpdateDto updatedLogDto)
        {
            
            var existingLog = await _context.DailyLogs.FindAsync(id);
            if (existingLog == null) return null;

            _mapper.Map(updatedLogDto, existingLog);
            await _context.SaveChangesAsync();

            return _mapper.Map<DailyLogResponseDto>(existingLog);
        }

        
        public async Task<bool> DeleteLogAsync(Guid id)
        {
            var log = await _context.DailyLogs.FindAsync(id);
            if (log == null) return false;

            
            _context.DailyLogs.Remove(log);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SeedTestDataAsync()
        {
            // Biztonsági fék: csak akkor fut le, ha teljesen üres az adatbázis
            if (_context.DailyLogs.Any()) return false;

            var logs = new List<DailyLog>();

            for (int i = 0; i < 14; i++)
            {
                var date = DateTime.UtcNow.AddDays(-i);

                var log = new DailyLog
                {
                    Date = date,
                    DayType = DayType.Pull, // Tegyük fel, hogy 1 = Edzésnap
                    BodyWeight = 82.5 - (i * 0.1), // Kis súlycsökkenés imitálása visszamenőleg
                    Exercises = new List<ExerciseSession>(),
                    Meals = new List<MealLog>()
                };

                // Adunk a naphoz két gyakorlatot
                log.Exercises.Add(new ExerciseSession
                {
                    ExerciseName = "Hack Squat",
                    Sets = 4,
                    Reps = 10,
                    Weight = 120
                });
                log.Exercises.Add(new ExerciseSession
                {
                    ExerciseName = "Fekvenyomás",
                    Sets = 3,
                    Reps = 8,
                    Weight = 80
                });

                // Adunk a naphoz pár étkezést / kiegészítőt
                log.Meals.Add(new MealLog
                {
                    MealName = "Thor Pre-workout",
                    Calories = 15,
                    Protein = 0,
                    Carbs = 3,
                    Fats = 0
                });
                log.Meals.Add(new MealLog
                {
                    MealName = "Monster Energy (Zero)",
                    Calories = 10,
                    Protein = 0,
                    Carbs = 2,
                    Fats = 0
                });
                log.Meals.Add(new MealLog
                {
                    MealName = "Csirke-rizs klasszik",
                    Calories = 650,
                    Protein = 55,
                    Carbs = 80,
                    Fats = 12
                });

                logs.Add(log);
            }

            await _context.DailyLogs.AddRangeAsync(logs);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
