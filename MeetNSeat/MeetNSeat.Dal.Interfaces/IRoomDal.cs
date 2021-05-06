using System.Collections.Generic;

namespace MeetNSeat.Dal.Interfaces
{
    public interface IRoomDal
    {
        List<RoomDto> GetAllRoomsByType(RoomDto roomDto);
    }
}