using System.Collections.Generic;
using MeetNSeat.Dal.Interfaces;

namespace MeetNSeat.Logic
{
    public interface IManageUser
    {
        IReadOnlyCollection<Reservation> GetAllReservations();
        List<ManageReservationDto> GetReservationByUser(string userId);
        bool DeleteReservation(int id);

    }
}
