namespace MeetNSeat.Dal.Interfaces
{
    public class RoomDto
    {
        public int RoomID { get; set; }
        public int LocationId { get; set; }
        public string Type { get; set; }
        public int Floor { get; set; }
        public int Spots { get; set; }
        public string Facilities { get; set; }


    }
}
