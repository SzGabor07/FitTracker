using FitTracker.Core.Entities;
using FitTracker.Services.Interfaces;
using FitTracker.Data;
using System;
using System.Collections.Generic;
using System.Text;
using FitTracker.Core.DTOs;
using AutoMapper;

namespace FitTracker.Services.Services
{
    public class ExerciseSessionService : IExerciseSessionService
    {
        private readonly FitTrackerDbContext _context;
        private readonly IMapper _mapper;
        public ExerciseSessionService(FitTrackerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ExerciseSessionResponseDto> AddExerciseToLogAsync(Guid dailyLogId, ExerciseSessionCreateDto newExerciseDto)
        {
            var exercise = _mapper.Map<ExerciseSession>(newExerciseDto);
            exercise.DailyLogId = dailyLogId;
            await _context.ExerciseSessions.AddAsync(exercise);
            await _context.SaveChangesAsync();

            return _mapper.Map<ExerciseSessionResponseDto>(exercise);
        }

        public async Task<ExerciseSessionResponseDto?> UpdateExerciseAsync(Guid id, ExerciseSessionUpdateDto updatedDto)
        {
            var existingExercise = await _context.ExerciseSessions.FindAsync(id);
            if (existingExercise == null) return null;

            _mapper.Map(updatedDto, existingExercise);

            await _context.SaveChangesAsync();
            return _mapper.Map<ExerciseSessionResponseDto>(existingExercise);
        }

        public async Task<bool> DeleteExerciseAsync(Guid id)
        {
            var existingExercise = await _context.ExerciseSessions.FindAsync(id);
            if (existingExercise == null) return false;

            _context.ExerciseSessions.Remove(existingExercise);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ExerciseSessionResponseDto?> GetExerciseByIdAsync(Guid id)
        {
            var exercise = await _context.ExerciseSessions.FindAsync(id);
            return exercise == null ? null : _mapper.Map<ExerciseSessionResponseDto>(exercise);
        }
    }
}
