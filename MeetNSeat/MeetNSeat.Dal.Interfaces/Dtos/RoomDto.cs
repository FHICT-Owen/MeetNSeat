namespace MeetNSeat.Dal.Interfaces.Dtos
{
    public class RoomDto
    {
        public int Id { get; set; }
        public int FloorId { get; set; }
        public string Type { get; set; }
        public int Spots { get; set; }
        public string Facilities { get; set; }

        public RoomDto() { }
        public RoomDto(int id, int floorId, string type, int spots, string facilities)
        {
            Id = id;
            FloorId = floorId;
            Type = type;
            Spots = spots;
            Facilities = facilities;
        }
        
        public RoomDto(string type)
        {
            Type = type;
        }
    }
}
