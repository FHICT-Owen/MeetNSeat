using System;
using System.Text.Json.Serialization;
using MeetNSeat.Logic;

namespace MeetNSeat.Client.Models
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