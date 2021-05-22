namespace MeetNSeat.Client.Models
{
    public class RoomModel
    {
        public int Id { get; set; }
        public int FloorId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Spots { get; set; }
        public string Facilities { get; set; }

        public RoomModel(int floorId, string name, string type, int spots, string facilities)
        {
            FloorId = floorId;
            Name = name;
            Type = type;
            Spots = spots;
            Facilities = facilities;
        }
    }
}
