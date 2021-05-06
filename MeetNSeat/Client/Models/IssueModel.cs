using System;
using System.Text.Json.Serialization;
using MeetNSeat.Logic;

namespace MeetNSeat.Client.Models
{
	public class IssueModel
	{
		public int Id { get; set; }
		public int RoomId { get; set; }
		public string UserId { get; set; }
		public string Description { get; set; }
		public DateTime CreatedOn { get; set; }
		public bool IsResolved { get; set; }
	}
}