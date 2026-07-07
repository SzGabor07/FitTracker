using System;

namespace FitTracker.Core.DTOs
{
    public class ExerciseSessionResponseDto
    {
        public Guid Id { get; set; }
        public string ExerciseName { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int Weight { get; set; }
    }
}