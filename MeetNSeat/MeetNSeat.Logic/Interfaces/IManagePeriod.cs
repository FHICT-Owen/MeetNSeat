using System;
using System.Collections.Generic;

namespace MeetNSeat.Logic.Interfaces
{
    public interface IManagePeriod
    {
        List<Period> GetPeriods(int locationId, string roomType, int attendees, DateTime startTime, DateTime endTime);
    }
}