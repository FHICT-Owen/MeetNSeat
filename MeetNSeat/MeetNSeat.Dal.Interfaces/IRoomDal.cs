using System.Collections.Generic;

namespace MeetNSeat.Dal.Interfaces
{
    public interface IRoomDal
    {
        List<RoomDto> GetAllRoomsByType(string type, int locationId);
    }
}