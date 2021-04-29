using System;
using MeetNSeat.Dal.Interfaces;

namespace MeetNSeat.Logic
{
    public class Issue
    {
	    public int Id { get; }
	    public int UserId { get; }
	    public int RoomId { get; }
	    public string Description { get; }
	    public DateTime CreatedOn { get; private set; }
	    public bool IsResolved { get; private set; }

	    public Issue(int id, int userId, int roomId, string description, DateTime createdOn, bool isResolved)
	    {
		    Id = id;
		    UserId = userId;
		    RoomId = roomId;
		    Description = description;
		    CreatedOn = DateTime.Now;
		    IsResolved = isResolved;
	    }

	    public Issue(IssueDto dto) {
		    Id = dto.Id;
		    UserId = dto.UserId;
		    RoomId = dto.RoomId;
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
		    return new IssueDto(Id, UserId, RoomId, Description, CreatedOn, IsResolved);
	    }
    }
}
