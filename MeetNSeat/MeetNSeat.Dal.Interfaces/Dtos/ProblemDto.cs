using System;
using System.Net.Mime;

namespace MeetNSeat.Dal.Interfaces.Dtos
{
	public class ProblemDto
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

		public ProblemDto() { }
		public ProblemDto(int id, string locationName, string roomName, string userId, string nickname, string email, string title, string description, byte[] picture, DateTime reportedOn, bool isResolved, DateTime? resolvedAt)
		{
			Id = id;
			LocationName = locationName;
			RoomName = roomName;
			UserId = userId;
			Nickname = nickname;
			Email = email;
			Title = title;
			Description = description;
			Picture = picture;
			ReportedOn = reportedOn;
			IsResolved = isResolved;
			ResolvedAt = resolvedAt;
		}
	}
}