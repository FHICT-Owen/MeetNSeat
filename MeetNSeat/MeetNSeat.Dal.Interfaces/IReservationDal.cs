using System.Collections.Generic;
using MeetNSeat.Dal.Interfaces;

namespace MeetNSeat.Dal.Interfaces
{
    public interface IReservationDal
    {
        List<ReservationDto> GetAllReservations(ReservationDto reservationDto);
        void AddReservation(ReservationDto reservationDto);
        void RemoveReservation(ReservationDto reservationDto);
        void UpdateReservation(ReservationDto reservationDto);
        List<ReservationDto> GetAllUserReservations(ReservationDto reservationDto);
    }
}