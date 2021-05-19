namespace MeetNSeat.Dal.Interfaces.Dtos
{
    public class RoomDto
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public string Type { get; set; }
        public int Floor { get; set; }
        public int Spots { get; set; }
        public string Facilities { get; set; }

        public RoomDto()
        {
            
        }
    }
}
