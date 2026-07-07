using System;
using System.Collections.Generic;
using System.Text;

namespace FitTracker.Core.DTOs
{
    public class DailyLogCreateDto
    {
        public DateTime Date { get; set; }
        public int DayType { get; set; }
        public double BodyWeight { get; set; }
    }
}
