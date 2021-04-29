using System;
using MeetNSeat.Dal.Interfaces;

namespace MeetNSeat.Logic
{
    public class Issue
    {
	    public int Id { get; }
	    public int RoomId { get; }
	    public int UserId { get; }
	    public string Description { get; }
	    public DateTime CreatedOn { get; }
	    public bool IsResolved { get; private set; }

	    public Issue(int userId, int roomId, string description)
	    {
		    RoomId = roomId;
		    UserId = userId;
		    Description = description;
		    CreatedOn = DateTime.Now;
		    IsResolved = false;
	    }

	    public Issue(IssueDto dto) {
		    Id = dto.Id;
		    RoomId = dto.RoomId;
		    UserId = dto.UserId;
		    Description = dto.Description;
		    CreatedOn = dto.CreatedOn;
		    IsResolved = dto.IsResolved;
	    }

	    public void Resolve()
	    {
		    IsResolved = true;
	    }

	    public IssueDto ConvertToDto()
	    {
		    return new IssueDto(RoomId, UserId, Description, CreatedOn, IsResolved);
	    }
    }
}
