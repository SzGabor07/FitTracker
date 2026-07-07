using System;
using System.Collections.Generic;
using System.Text;

namespace FitTracker.Core.DTOs
{
    public class DailyLogUpdateDto
    {
        public DateTime Date { get; set; }
        public int DayType { get; set; }
        public double BodyWeight { get; set; }
    }
}
