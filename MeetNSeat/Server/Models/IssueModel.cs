namespace MeetNSeat.Server.Models
{
	public class IssueModel
	{
		public int Id { get; set; }
		public int RoomId { get; set; }
		public string UserId { get; set; }
		public string Description { get; set; }
		public bool IsResolved { get; set; }
	}
}