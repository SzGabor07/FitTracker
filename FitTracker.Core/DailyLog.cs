using System;
using System.Collections.Generic;
using System.Text;
using FitTracker.Core.Enums;

namespace FitTracker.Core.Entities
{
    public class DailyLog
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Date { get; set; }
        public DayType DayType { get; set; }
        public double? BodyWeight { get; set; }

        public ICollection<ExerciseSession> Exercises { get; set; } = new List<ExerciseSession>();
        public ICollection<MealLog> Meals { get; set; } = new List<MealLog>();
    }
}
