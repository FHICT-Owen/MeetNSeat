using System.Collections.Generic;
using MeetNSeat.Dal.Interfaces;

namespace MeetNSeat.Dal.Interfaces
{
    public interface IRoomDal
    {
        List<RoomDto> GetAllRooms();
    }
}