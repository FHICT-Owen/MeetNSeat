using System;

namespace MeetNSeat.Server.Models
{
	public class IssueModel
	{
		public string Description { get; set; }
		public int RoomId { get; set; }
		public string UserId { get; set; }
	}
}