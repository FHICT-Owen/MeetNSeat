using System;

namespace MeetNSeat.Logic.Interfaces
{
    public interface IManageReservation
    {
        public bool AddReservation(int roomId, string type, int locationId, string userId, int attendees, DateTime startTime, DateTime endTime);

        public bool EditReservation(Reservation reservation);
    }
}
