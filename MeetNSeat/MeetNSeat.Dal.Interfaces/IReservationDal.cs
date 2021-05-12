using System.Collections.Generic;

namespace MeetNSeat.Dal.Interfaces
{
    public interface IReservationDal
    {
        List<ManageReservationDto> GetAllReservations();
        bool AddReservation(ReservationDto reservationDto);
        bool RemoveReservation(int id);
        void UpdateReservation(ReservationDto reservationDto);
        List<ManageReservationDto> GetReservationByUser(string id);
    }
}