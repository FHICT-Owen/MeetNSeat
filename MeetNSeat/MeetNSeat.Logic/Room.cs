using System.Collections.Generic;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Logic
{
    public class Room
    {
        private readonly IRoomDal _dal;

        public int Id { get; set; }
        public int FloorId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Spots { get; set; }
        public string Facilities { get; set; }

        public Room(string type)
        {
            Type = type;
        }

        public Room(RoomDto roomDto)
        {
            if (roomDto != null) //TODO: FIX THIS WHEN MAPPING OBJECTS IN DAL
            {
                Id = roomDto.Id;
                FloorId = roomDto.FloorId;
                Name = roomDto.Name;
                Type = roomDto.Type;
                Spots = roomDto.Spots;
                Facilities = roomDto.Facilities;
            }
        }

        // public Room(RoomDto roomDto) : this(roomDto.Type){}

        public Room()
        {
            _dal = RoomFactory.CreateRoomDal();
        }

        public List<RoomDto> GetAvailableRooms(string type, int locationId)
        {
            return _dal.GetAllRoomsByType(type, locationId);
        }

        public IReadOnlyCollection<RoomDto> GetRoomTypes()
        {
            return _dal.GetAllRoomTypes();
        }
    }
}
