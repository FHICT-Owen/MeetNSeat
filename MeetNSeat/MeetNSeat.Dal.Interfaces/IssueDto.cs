using System;

namespace MeetNSeat.Dal.Interfaces
{
	public class IssueDto
	{
		public int Id { get; set; }
		public int RoomId { get; set; }
		public int UserId { get; set; }
		public string Description { get; set; }
		public DateTime CreatedOn { get; set; }
		public bool IsResolved { get; set; }

		public IssueDto(int id, int userId, int roomId, string description, DateTime createdOn, bool isResolved)
		{
			Id = id;
			UserId = userId;
			RoomId = roomId;
			Description = description;
			CreatedOn = createdOn;
			IsResolved = isResolved;
		}
	}
}