namespace MeetNSeat.Dal.Interfaces.Dtos
{
    public class RoomDto
    {
        public int Id { get; set; }
        public int FloorId { get; set; }
        public string Name { get; set; }
        public string RoomType { get; set; }
        public int Spots { get; set; }
        public string Facilities { get; set; }
        public bool IsAvailable { get; set; }

        public RoomDto() { }

        public RoomDto(int id, int floorId, string name, string type, int spots, string facilities)
        {
            Id = id;
            FloorId = floorId;
            Name = name;
            RoomType = type;
            Spots = spots;
            Facilities = facilities;
        }
        
        public RoomDto(string type)
        {
            RoomType = type;
        }
    }
}
