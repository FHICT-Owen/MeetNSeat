using System;
using System.Collections.Generic;
using MeetNSeat.Dal.Interfaces;

namespace MeetNSeat.Logic
{
    public interface IManageUser
    {
        IReadOnlyCollection<Reservation> GetAllReservations();
        List<ManageReservationDto> GetReservationByUser(string userId);

        bool AddReservation(string type, int locationId, string userId, int attendees, DateTime startTime,
            DateTime endTime);
    }
}
