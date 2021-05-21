using System;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Logic
{
    public class Issue
    {
	    public int Id { get; }
	    public int RoomId { get; private set; }
	    public string UserId { get; private set; }
	    public string Description { get; private set; }
	    public DateTime CreatedOn { get; }
	    public bool IsResolved { get; private set; }

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

	    public void Update(string description, int roomId, string userId, bool isResolved)
	    {
		    RoomId = roomId;
		    UserId = userId;
		    Description = description;
		    IsResolved = isResolved;
		    IssueFactory.CreateIssueDal().Update(ConvertToDto());
	    }

	    public IssueDto ConvertToDto()
	    {
		    return new (Id, RoomId, UserId, Description, CreatedOn, IsResolved);
	    }
    }
}
