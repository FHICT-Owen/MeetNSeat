namespace MeetNSeat.Dal.Interfaces
{
	public class IssueDto
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int RoomId { get; set; }
		public string IssueDescription { get; set; }
		public bool IsResolved { get; set; }

		public IssueDto(int id, int userId, int roomId, string issueDescription, bool isResolved)
		{
			Id = id;
			UserId = userId;
			RoomId = roomId;
			IssueDescription = issueDescription;
			IsResolved = isResolved;
		}
	}
}