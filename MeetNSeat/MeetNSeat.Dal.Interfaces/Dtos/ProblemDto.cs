using System;
using System.Net.Mime;

namespace MeetNSeat.Dal.Interfaces.Dtos
{
	public class ProblemDto
	{
		public int Id { get; set; }
		public int RoomId { get; set; }
		public string UserId { get; set; }
		public string Email { get; set; }
		public string Description { get; set; }
		public byte[] Picture { get; set; }
		public DateTime ReportedOn { get; set; }
		public bool IsResolved { get; set; }
		public DateTime? ResolvedAt { get; set; }

		public ProblemDto() { }
		public ProblemDto(int id, int roomId, string userId, string email, string description, byte[] picture, DateTime reportedOn, bool isResolved, DateTime? resolvedAt)
		{
			Id = id;
			RoomId = roomId;
			UserId = userId;
			Email = email;
			Description = description;
			Picture = picture;
			ReportedOn = reportedOn;
			IsResolved = isResolved;
			ResolvedAt = resolvedAt;
		}
	}
}