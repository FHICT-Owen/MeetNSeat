using System.Collections.Generic;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Logic
{
    public class Location
    {
        private readonly List<Floor> _floors = new();
        private readonly IRoomDal _dal;

        public List<Floor> Floors { get; set; }
        
        public Location()
        {
            _dal = RoomFactory.CreateRoomDal();
        }

        public IReadOnlyCollection<RoomDto> GetAvailableRooms(string type, int locationId)
        {
            return _dal.GetAllRoomsByType(type, locationId).AsReadOnly();
        }
    }
}
