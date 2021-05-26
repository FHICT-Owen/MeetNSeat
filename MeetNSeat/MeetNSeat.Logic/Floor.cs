using System.Collections.Generic;
using MeetNSeat.Dal;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Dal.Interfaces.Dtos;
using MeetNSeat.Logic.Interfaces;

namespace MeetNSeat.Logic
{
    public class Floor : IManageRoom
    {
        private readonly IRoomDal _dal;
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public List<Room> Rooms { get; set; } = new();
        
        public Floor(string name, int locationId)
        {
            Name = name;
            LocationId = locationId;
        }

        public Floor()
        {
            _dal = RoomFactory.CreateRoomDal();
        }

        public Floor(FloorDto floorDto)
        {
            Id = floorDto.Id;
            Name = floorDto.Name;
            LocationId = floorDto.LocationId;
            if (floorDto.Rooms == null) return;
            foreach (var room in floorDto.Rooms)
                Rooms.Add(new Room(room));
        }

        public FloorDto ConvertToDto()
        {
            return new(Id, Name, LocationId);
        }

        public void AddRoom(int floorId, string name, string type, int spots, string facilities)
        {
            var room = new Room(floorId, name, spots, type, facilities);
            Rooms.Add(room);
            _dal.AddRoom(room.ConvertToDto());
        }

        public IReadOnlyCollection<Room> GetAllIssues()
        {
            throw new System.NotImplementedException();
        }
    }
}
