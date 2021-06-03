using System;

namespace MeetNSeat.Client.Models
{
	public class ProblemModel
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

		public ProblemModel(int roomId, string userId, string email, string description, byte[] picture)
		{
			RoomId = roomId;
			UserId = userId;
			Email = email;
			Description = description;
			Picture = picture;
		}
	}
}