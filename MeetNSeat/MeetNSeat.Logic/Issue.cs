using MeetNSeat.Dal.Interfaces;

namespace MeetNSeat.Logic
{
    public class Issue
    {
	    public int IssueId { get; private set; }
	    public int UserId { get; private set; }
	    public int RoomId { get; private set; }
	    public string IssueDescription { get; private set; }
	    public bool IsResolved { get; private set; }

	    public Issue(int issueId, int userId, int roomId, string issueDescription)
	    {
		    IssueId = issueId;
		    UserId = userId;
		    RoomId = roomId;
		    IssueDescription = issueDescription;
	    }

	    public Issue(IssueDto dto) {
		    IssueId = dto.IssueId;
		    UserId = dto.UserId;
		    RoomId = dto.RoomId;
		    IssueDescription = dto.IssueDescription;
	    }

	    public void Resolve()
	    {
		    IsResolved = true;
	    }

	    public IssueDto ConvertToDto()
	    {
		    return new IssueDto(IssueId, UserId, RoomId, IssueDescription, IsResolved);
	    }
    }
}
