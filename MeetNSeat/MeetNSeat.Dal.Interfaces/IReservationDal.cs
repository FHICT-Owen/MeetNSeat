using System.Collections.Generic;
using MeetNSeat.Dal.Interfaces;

namespace MeetNSeat.Dal.Interfaces
{
    public interface IReservationDal
    {
        List<ReservationDto> GetAllReservations();
        void AddReservation(ReservationDto reservationDto);
        void RemoveReservation(ReservationDto reservationDto);
        void UpdateReservation(ReservationDto reservationDto);
        List<ReservationDto> GetReservationByUser(int id);
    }
}