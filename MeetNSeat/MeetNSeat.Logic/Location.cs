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

        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string IpAddress { get; set; }
        
        public Location()
        {
            _dal = RoomFactory.CreateRoomDal();
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

        public IReadOnlyCollection<RoomDto> GetAvailableRooms(string type, int locationId)
        {
            return _dal.GetAllRoomsByType(type, locationId).AsReadOnly();
        }
        
        public LocationDto ConvertToDto()
        {
            return new (Id, Name, City, IpAddress);
        }
    }
}
