using System.Collections.Generic;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Logic
{
    public class Floor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public List<Room> Rooms { get; set; } = new();
        
        public Floor(string name, int locationId)
        {
            Name = name;
            LocationId = locationId;
        }

        public Floor(FloorDto floorDto)
        {
            Id = floorDto.Id;
            Name = floorDto.Name;
            LocationId = floorDto.LocationId;
            foreach (var room in floorDto.Rooms)
                Rooms.Add(new Room(room));
        }

        public FloorDto ConvertToDto()
        {
            return new(Id, Name, LocationId);
        }
    }
}
