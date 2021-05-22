using System.Collections.Generic;

namespace MeetNSeat.Dal.Interfaces.Dtos
{
    public class FloorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public List<RoomDto> Rooms { get; set; }

        public FloorDto() { }
        public FloorDto(int id, string name, int locationId)
        {
            Id = id;
            Name = name;
            LocationId = locationId;
        }
    }
}
