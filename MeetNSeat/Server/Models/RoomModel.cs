namespace MeetNSeat.Server.Models
{
	public class RoomModel
	{
		public int Id { get; set; }
		public int FloorId { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public int Spots { get; set; }
		public string Facilities { get; set; }
	}
}