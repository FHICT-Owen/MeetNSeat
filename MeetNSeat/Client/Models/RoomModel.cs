namespace MeetNSeat.Client.Models
{
    public class RoomModel
    {
        public int RoomId { get; set; }
        public int LocationId { get; set; }
        public int Floor { get; set; }
        public string Type { get; set; }
        public int Spots { get; set; }
        public string Facilities { get; set; }

        public RoomModel(int roomId, int locationId, int floor, string type, int spots, string facilities)
        {
            RoomId = roomId;
            LocationId = locationId;
            Floor = floor;
            Type = type;
            Spots = spots;
            Facilities = facilities;
        }
    }
}
