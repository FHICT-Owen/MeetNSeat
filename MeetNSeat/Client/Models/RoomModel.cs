namespace MeetNSeat.Client.Models
{
    public class RoomModel
    {
        public int Id { get; set; }
        public int FloorId { get; set; }
        public string Type { get; set; }
        public int Spots { get; set; }
        public string Facilities { get; set; }

        public RoomModel(int id, int floorId, string type, int spots, string facilities)
        {
            Id = id;
            FloorId = floorId;
            Type = type;
            Spots = spots;
            Facilities = facilities;
        }
    }
}
