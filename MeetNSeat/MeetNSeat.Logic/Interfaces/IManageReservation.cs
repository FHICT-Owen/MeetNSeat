using System;
using System.Collections.Generic;
using System.Text;

namespace MeetNSeat.Logic.Interfaces
{
    public interface IManageReservation
    {
        public void AddReservation(string type, int locationId, string userId, int feedbackId, int attendees, DateTime startTime, DateTime endTime);
    }
}
