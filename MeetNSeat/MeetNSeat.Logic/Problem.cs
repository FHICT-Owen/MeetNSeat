using System;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Logic
{
    public class Problem
    {
	    public int Id { get; set; }
	    public int RoomId { get; set; }
	    public string UserId { get; set; }
	    public string Email { get; set; }
	    public string Description { get; set; }
	    public byte[] Picture { get; set; }
	    public DateTime ReportedOn { get; set; }
	    public bool IsResolved { get; set; }
	    public DateTime? ResolvedAt { get; set; }

	    public Problem(int roomId, string userId, string email, string description, byte[] picture) // create issue
	    {
		    RoomId = roomId;
		    UserId = userId;
		    Email = email;
		    Description = description;
		    Picture = picture;
		    ReportedOn = DateTime.Now;
		    IsResolved = false;
		    ResolvedAt = null;
	    }

	    public Problem(ProblemDto dto)
	    {
		    Id = dto.Id;
		    RoomId = dto.RoomId;
		    UserId = dto.UserId;
		    Email = dto.Email;
		    Description = dto.Description;
		    Picture = dto.Picture;
		    ReportedOn = dto.ReportedOn;
		    IsResolved = dto.IsResolved;
		    ResolvedAt = dto.ResolvedAt;
	    }

	    public void Update(int roomId, string userId, string email, string description, byte[] picture, bool isResolved, DateTime? resolvedAt)
	    {
		    RoomId = roomId;
		    UserId = userId;
		    Email = email;
		    Description = description;
		    Picture = picture;
		    IsResolved = isResolved;
		    ResolvedAt = resolvedAt;
		    ProblemFactory.CreateIssueDal().UpdateProblem(ConvertToDto());
	    }

	    public ProblemDto ConvertToDto()
	    {
		    return new (Id, RoomId, UserId, Email, Description, Picture, ReportedOn, IsResolved, ResolvedAt);
	    }
    }
}
