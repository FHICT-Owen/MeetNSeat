using System.Collections.Generic;

namespace MeetNSeat.Dal.Interfaces
{
    public interface IReservationDal
    {
        List<ManageReservationDto> GetAllReservations();
        bool AddReservation(ReservationDto reservationDto);
        void RemoveReservation(ReservationDto reservationDto);
        void UpdateReservation(ReservationDto reservationDto);
        List<ManageReservationDto> GetReservationByUser(string id);
    }
}