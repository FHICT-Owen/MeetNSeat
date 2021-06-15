using System;
using System.Collections.Generic;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Logic.Interfaces
{
    public interface IManageUser
    {
        IReadOnlyCollection<Reservation> GetAllReservations();
        IReadOnlyCollection<ReservationDto> GetReservationByUser(string id);
        bool AddReservation(string type,int roomId,int locationId, string userId, int attendees, DateTime startTime, DateTime endTime);

        List<RoomDto> GetAvailableRooms(int locationId, string roomType, int attendees, DateTime startTime, DateTime endTime, int roomId);

        bool EditReservation(Reservation reservation);
        bool DeleteReservation(int id);
        IReadOnlyCollection<Room> GetAllRoomTypes();

    }
}
