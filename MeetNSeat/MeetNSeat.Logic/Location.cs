using System.Collections.Generic;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Logic
{
    public class Location
    {
        private readonly Room _room = new();
        private readonly IRoomDal _dal;
        
        public Location()
        {
            _dal = RoomFactory.CreateRoomDal();
        }

        public List<RoomDto> GetAvailableRooms(string type, int locationId)
        {
            return _dal.GetAllRoomsByType(type, locationId);
        }
    }
}
