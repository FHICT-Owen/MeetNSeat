using System.Collections.Generic;

namespace MeetNSeat.Dal.Interfaces
{
    public interface IReservationDal
    {
        List<ManageReservationDto> GetAllReservations();
        bool AddReservation(CreateReservationDto createReservationDto);
        bool RemoveReservation(int id);
        void UpdateReservation(ReservationDto reservationDto);
        List<ManageReservationDto> GetReservationByUser(string id);
    }
}