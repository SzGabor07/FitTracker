using System;
using System.Collections.Generic;
using System.Text;

namespace FitTracker.Core.Entities
{
    public class MealLog
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid DailyLogId { get; set; }
        public string MealName { get; set; }
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Carbs { get; set; }
        public double Fats { get; set; }
        public DailyLog? DailyLog { get; set; }
    }
}
