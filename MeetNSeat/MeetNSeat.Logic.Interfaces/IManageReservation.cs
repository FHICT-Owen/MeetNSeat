using System;
using System.Collections.Generic;
using System.Text;

namespace MeetNSeat.Logic.Interfaces
{
    public interface IManageReservation
    {
        public void AddReservation(int roomId, int userId, int attendees, DateTime startTime, DateTime endTime);
    }
}
