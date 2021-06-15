using System;
using System.Collections.Generic;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Dal.Interfaces
{
    public interface IReservationDal
    {
        List<ReservationDto> GetAllReservations();
        bool AddReservation(CreateReservationDto createReservationDto);
        bool ConfirmReservation(int id, DateTime? confirmedTime);
        bool RemoveReservation(int id);
        bool UpdateReservation(ReservationDto reservationDto);
        List<ReservationDto> GetReservationByUser(string id);
    }
}