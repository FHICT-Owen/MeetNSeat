using System;

namespace MeetNSeat.Server.Models
{
	public class ProblemModel
	{
		public int Id { get; set; }
		public int RoomId { get; set; }
		public string UserId { get; set; }
		public string Email { get; set; }
		public string Description { get; set; }
		public byte[] Picture { get; set; }
		public bool IsResolved { get; set; }
		public DateTime? ResolvedAt { get; set; }
		
		// public int Id { get; set; }
		// public int RoomId { get; set; }
		// public string UserId { get; set; }
		// public string Email { get; set; }
		// public string Description { get; set; }
		// public byte[] Picture { get; set; }
		// public DateTime ReportedOn { get; set; }
		// public bool IsResolved { get; set; }
		// public DateTime? ResolvedAt { get; set; }
	}
}