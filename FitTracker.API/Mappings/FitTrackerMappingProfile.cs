using AutoMapper;
using FitTracker.Core.DTOs;
using FitTracker.Core.Entities;

namespace FitTracker.API.Mappings
{
    public class FitTrackerMappingProfile : Profile
    {
        public FitTrackerMappingProfile()
        {
            CreateMap<ExerciseSessionUpdateDto, ExerciseSession>();
            CreateMap<ExerciseSessionCreateDto, ExerciseSession>();
            CreateMap<ExerciseSession, ExerciseSessionResponseDto>();

            CreateMap<MealLogCreateDto, MealLog>();
            CreateMap<MealLogUpdateDto, MealLog>();
            CreateMap<MealLog, MealLogResponseDto>();

            CreateMap<DailyLogCreateDto, DailyLog>();
            CreateMap<DailyLogUpdateDto, DailyLog>();
            CreateMap<DailyLog, DailyLogResponseDto>();
        }
    }
}
