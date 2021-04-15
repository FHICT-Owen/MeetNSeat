using System.Collections.Generic;
using MeatNSeat.Dal.Interfaces;

namespace MeatNSeat.Dal.Interfaces
{
    public interface IReservationDal
    {
        List<ReservationDto> GetAllReservations();
        void AddReservation(ReservationDto reservationDto);
        void RemoveReservation(ReservationDto reservationDto);
        void UpdateReservation(ReservationDto reservationDto);
    }
}