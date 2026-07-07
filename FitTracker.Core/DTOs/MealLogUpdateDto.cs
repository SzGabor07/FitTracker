using System;
using System.Collections.Generic;
using System.Text;

namespace FitTracker.Core.DTOs
{
    public class MealLogUpdateDto
    {
        public string MealName { get; set; }
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Carbs { get; set; }
        public double Fats { get; set; }
    }
}
