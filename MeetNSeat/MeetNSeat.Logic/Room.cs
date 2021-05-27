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
        public int Spots { get; set; }
        public string Type { get; set; }
        public string Facilities { get; set; }

        public Room(string type)
        {
            Type = type;
        }

        public Room(int id, int floorId, string name, int spots, string type, string facilities)
        {
            Id = id;
            FloorId = floorId;
            Name = name;
            Spots = spots;
            Type = type;
            Facilities = facilities;
        }
        public Room(RoomDto roomDto)
        {
            Id = roomDto.Id;
            FloorId = roomDto.FloorId;
            Name = roomDto.Name;
            Type = roomDto.RoomType;
            Spots = roomDto.Spots;
            Facilities = roomDto.Facilities;
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

        public RoomDto ConvertToDto()
        {
            return new(Id, FloorId, Name, Type, Spots, Facilities);
        }
    }
}
