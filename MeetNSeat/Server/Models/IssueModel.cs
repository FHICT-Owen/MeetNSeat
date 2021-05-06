using System;

namespace MeetNSeat.Server.Models
{
	public class IssueModel
	{
		public int Id { get; }
		public int RoomId { get; }
		public string UserId { get; }
		public string Description { get; }
		public DateTime CreatedOn { get; }
		public bool IsResolved { get; private set; }
	}
}