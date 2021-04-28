namespace MeetNSeat.Dal.Interfaces
{
	public class IssueDto
	{
		public int IssueId { get; set; }
		public int UserId { get; set; }
		public int RoomId { get; set; }
		public string IssueDescription { get; set; }
		public bool IsResolved { get; set; }

		public IssueDto(int issueId, int userId, int roomId, string issueDescription, bool isResolved)
		{
			IssueId = issueId;
			UserId = userId;
			RoomId = roomId;
			IssueDescription = issueDescription;
			IsResolved = isResolved;
		}
	}
}