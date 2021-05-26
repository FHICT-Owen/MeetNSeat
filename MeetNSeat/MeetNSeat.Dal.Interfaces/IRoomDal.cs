using System.Collections.Generic;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Dal.Interfaces
{
    public interface IRoomDal
    {
        List<RoomDto> GetAllRoomsByType(string type, int locationId);
        void AddRoom(RoomDto room);
        List<RoomDto> GetAllRooms();
        public IReadOnlyCollection<RoomDto> GetAllRoomTypes();
    }
}