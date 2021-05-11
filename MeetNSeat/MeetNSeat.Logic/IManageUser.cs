using System.Collections.Generic;

namespace MeetNSeat.Logic
{
    public interface IManageUser
    {
        IReadOnlyCollection<Reservation> GetAllReservations();

    }
}
