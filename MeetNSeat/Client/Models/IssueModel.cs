using System;

namespace MeetNSeat.Client.Models
{
	public class IssueModel
	{
		public string Description { get; set; }
		public int RoomId { get; set; }
		public string UserId { get; set; }
		public DateTime CreatedOn { get; set; }
		public bool IsResolved { get; set; }

		public IssueModel(string description)
		{
			Description = description;
			RoomId = 1;
			UserId = "test";
		}
	}
}