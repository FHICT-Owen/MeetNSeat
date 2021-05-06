using System;
using System.Collections.Generic;
using System.Text;

namespace MeetNSeat.Logic.Interfaces
{
    public interface IManageReservation
    {
        public void AddReservation(int roomId, string userId, int feedbackId, int attendees, DateTime startTime, DateTime endTime);
    }
}
