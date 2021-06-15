using System;

namespace MeetNSeat.Server.Models
{
	public class ProblemModel
	{
		public int Id { get; set; }
		public string LocationName { get; set; }
		public string RoomName { get; set; }
		public string UserId { get; set; }
		public string Nickname { get; set; }
		public string Email { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public byte[] Picture { get; set; }
		public DateTime ReportedOn { get; set; }
		public bool IsResolved { get; set; }
		public DateTime? ResolvedAt { get; set; }
	}
}