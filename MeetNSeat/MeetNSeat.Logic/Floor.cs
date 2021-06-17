using System.Collections.Generic;
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
            _dal = RoomFactory.CreateRoomDal();
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
            floorDto.Rooms?.ForEach(room => {
                if (room != null) Rooms.Add(new Room(room));
            });
            _dal = RoomFactory.CreateRoomDal();
        }

        public FloorDto ConvertToDto()
        {
            return new(Id, Name, LocationId);
        }

        public void AddRoom(int floorId, string name, string type, int spots, string facilities)
        {
            var room = new Room(0, floorId, name, spots, type, facilities);
            Rooms.Add(room);
            _dal.AddRoom(room.ConvertToDto());
        }
        
        public void DeleteRoom(int id)
        {
            Rooms.Remove(Rooms.Find(issue => issue.Id == id));
            _dal.DeleteRoomById(id);
        }
        
        public void UpdateRoom(int id, string name, string type, int spots, string facilities)
        {
            var room = new Room(id, 0, name, spots, type, facilities);
            room.ConvertToDto();
            _dal.Update(room.ConvertToDto());
        }

        public IReadOnlyCollection<Room> GetAllRooms()
        {
            var rooms = new List<Room>();
            _dal.GetAllRooms().ForEach(res => rooms.Add(new Room(res)));
            return rooms.AsReadOnly();
        }

        public void Update(int id, string name, int locationId)
        {
            Id = id;
            Name = name;
            LocationId = locationId;
            FloorFactory.CreateFloorDal().Update(ConvertToDto());
        }
    }
}
