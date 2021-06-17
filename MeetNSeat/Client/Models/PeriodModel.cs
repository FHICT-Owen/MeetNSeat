using System;
using System.Collections.Generic;

namespace MeetNSeat.Client.Models
{
    public class PeriodModel
    {
        public DayOfWeek DayOfWeek { get; set; }
        public List<DateTime> DateTimes { get; set; } = new();
        public List<int> Heights { get; set; } = new();

        public PeriodModel()
        {
            for (var i = 0; i < DateTimes.Count-1; i++)
            {
                Heights.Add((int)(DateTimes[i+1] - DateTimes[i]).TotalMinutes);
            }
        }
    }
}