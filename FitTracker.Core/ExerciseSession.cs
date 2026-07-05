using System;
using System.Collections.Generic;
using System.Text;

namespace FitTracker.Core.Entities
{
    public class ExerciseSession
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid DailyLogId { get; set; }
        public string ExerciseName { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int Weight { get; set; }
        public DailyLog? DailyLog { get; set; }
    }
}
