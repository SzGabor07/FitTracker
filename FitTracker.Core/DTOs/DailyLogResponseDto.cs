using System;
using System.Collections.Generic;
using System.Text;

namespace FitTracker.Core.DTOs
{
    public class DailyLogResponseDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int DayType { get; set; }
        public double BodyWeight { get; set; }

        
        public List<ExerciseSessionResponseDto> Exercises { get; set; } = new List<ExerciseSessionResponseDto>();
        public List<MealLogResponseDto> Meals { get; set; } = new List<MealLogResponseDto>();
    }
}
