using System;
using System.Collections.Generic;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Logic.Interfaces
{
    public interface IManageUser
    {
        IReadOnlyCollection<Reservation> GetAllReservations();
        List<ManageReservationDto> GetReservationByUser(string userId);
        bool AddReservation(string type, int locationId, string userId, int attendees, DateTime startTime,
            DateTime endTime);
        bool ConfirmReservation(int id, string ip);
        bool DeleteReservation(int id);
        IReadOnlyCollection<Room> GetAllRoomTypes();

    }
}
