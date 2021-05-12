using System;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Logic
{
    public class Issue
    {
	    private int Id { get; }
	    private int RoomId { get; }
	    private string UserId { get; }
	    private string Description { get; }
	    private DateTime CreatedOn { get; }
	    private bool IsResolved { get; set; }

	    public Issue(string description, int roomId, string userId)
	    {
		    Description = description;
		    RoomId = roomId;
		    UserId = userId;
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
		    return new IssueDto(Id, RoomId, UserId, Description, CreatedOn, IsResolved);
	    }
    }
}
