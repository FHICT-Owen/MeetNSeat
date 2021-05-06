using System.Collections.Generic;

namespace MeetNSeat.Dal.Interfaces
{
    public interface IReservationDal
    {
        List<ReservationDto> GetAllReservations();
        bool AddReservation(ReservationDto reservationDto);
        void RemoveReservation(ReservationDto reservationDto);
        void UpdateReservation(ReservationDto reservationDto);
        List<ReservationDto> GetReservationByUser(int id);
    }
}