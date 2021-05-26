using System.Collections.Generic;
using System.Linq;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Dal.Interfaces.Dtos;
using MeetNSeat.Logic.Interfaces;

namespace MeetNSeat.Logic
{
    public class Location : IManageFloor
    {
        private readonly List<Floor> _floors = new ();
        private readonly IFloorDal _floorDal;
        private readonly IRoomDal _roomDal;

        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string IpAddress { get; set; }
        
        public Location()
        {
            _roomDal = RoomFactory.CreateRoomDal();
            _floorDal = FloorFactory.CreateFloorDal();
        }

        public Location(int id, string name, string city, string ipAddress)
        {
            Id = id;
            Name = name;
            City = city;
            IpAddress = ipAddress;
        }

        public Location(LocationDto locationDto)
        {
            Id = locationDto.Id;
            Name = locationDto.Name;
            City = locationDto.City;
            IpAddress = locationDto.IpAddress;
        }
        
        public IReadOnlyCollection<Floor> GetAllRoomsAndFloorByLocationId(int locationId)
        {
            _floors.Clear();
            
            _floorDal.GetAllRoomsAndFloorByLocationId(locationId).ForEach(
                dto => _floors.Add(new Floor(dto)));
            
            return _floors.AsReadOnly();
        }

        public IReadOnlyCollection<Floor> GetAllFloors()
        {
            var floors = new List<Floor>();
            _floorDal.GetAllFloors().ForEach(res => floors.Add(new Floor(res)));
            return floors.AsReadOnly();
        }

        public void AddFloor(int locationId, string name)
        {
            var floor = new Floor(name, locationId);
            _floors.Add(floor);
            _floorDal.AddFloor(floor.ConvertToDto());
        }
        
        
        
        public IReadOnlyCollection<RoomDto> GetAllRoomsWithType(string type, int locationId)
        {
            List<RoomDto> rooms = new List<RoomDto>();

            var floors = _floorDal.GetAllRoomsAndFloorByLocationId(locationId);

            foreach (var floor in floors)
            {
                foreach (var room in floor.Rooms)
                {
                    if (room == null) continue;
                    if (room.Type == type)
                    {
                        rooms.Add(room);
                    }
                }
            }

            return rooms.AsReadOnly();
        }

        public LocationDto ConvertToDto()
        {
            return new (Id, Name, City, IpAddress);
        }
    }
}
