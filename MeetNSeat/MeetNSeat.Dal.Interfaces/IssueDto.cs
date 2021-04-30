using System;

namespace MeetNSeat.Dal.Interfaces
{
	public class IssueDto
	{
		public int Id { get; set; }
		public int RoomId { get; set; }
		public string UserId { get; set; }
		public string Description { get; set; }
		public DateTime CreatedOn { get; set; }
		public bool IsResolved { get; set; }

		public IssueDto(int roomId, string userId, string description, DateTime createdOn, bool isResolved)
		{
			RoomId = roomId;
			UserId = userId;
			Description = description;
			CreatedOn = createdOn;
			IsResolved = isResolved;
		}
	}
}