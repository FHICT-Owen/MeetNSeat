using System;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Logic
{
    public class Problem
    {
	    public int Id { get; set; }
	    public string LocationName { get; set; }
	    public string RoomName { get; set; }
	    public string UserId { get; set; }
	    public string Nickname { get; set; }
	    public string Email { get; set; }
	    public string Title { get; set; }
	    public string Description { get; set; }
	    public byte[] Picture { get; set; }
	    public DateTime ReportedOn { get; set; }
	    public bool IsResolved { get; set; }
	    public DateTime? ResolvedAt { get; set; }

	    public Problem(string locationName, string roomName, string userId, string nickname, string email, string title, string description, byte[] picture) // create problem
	    {
		    LocationName = locationName;
		    RoomName = roomName;
		    UserId = userId;
		    Nickname = nickname;
		    Email = email;
		    Title = title;
		    Description = description;
		    Picture = picture;
		    ReportedOn = DateTime.Now;
		    IsResolved = false;
		    ResolvedAt = null;
	    }

	    public Problem(ProblemDto dto)
	    {
		    Id = dto.Id;
		    LocationName = dto.LocationName;
		    RoomName = dto.RoomName;
		    UserId = dto.UserId;
		    Nickname = dto.Nickname;
		    Email = dto.Email;
		    Title = dto.Title;
		    Description = dto.Description;
		    Picture = dto.Picture;
		    ReportedOn = dto.ReportedOn;
		    IsResolved = dto.IsResolved;
		    ResolvedAt = dto.ResolvedAt;
	    }

	    public void Update(string locationName, string roomName, string userId, string nickname, string email, string title, string description, byte[] picture, bool isResolved, DateTime? resolvedAt)
	    {
		    LocationName = locationName;
		    RoomName = roomName;
		    UserId = userId;
		    Nickname = nickname;
		    Email = email;
		    Title = title;
		    Description = description;
		    Picture = picture;
		    IsResolved = isResolved;
		    ResolvedAt = resolvedAt;
		    ProblemFactory.CreateIssueDal().UpdateProblem(ConvertToDto());
	    }

	    public ProblemDto ConvertToDto()
	    {
		    return new (Id, LocationName, RoomName, UserId, Nickname, Email, Title, Description, Picture, ReportedOn, IsResolved, ResolvedAt);
	    }
    }
}
