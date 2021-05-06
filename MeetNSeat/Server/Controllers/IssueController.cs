using MeetNSeat.Logic;
using MeetNSeat.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetNSeat.Server.Controllers
{
	[Route("api/issues")]
	[ApiController]
	public class IssueController : ControllerBase
	{
		private readonly IManageIssue _manageIssue;

		public IssueController(IManageIssue manageIssue)
		{
			_manageIssue = manageIssue;
		}
		
		[HttpGet]
		public ActionResult GetAllIssues()
		{
			var issues = _manageIssue.GetAllIssues();
			return Ok(issues);
		}
		
		// [HttpPost]
		// public void AddIssue(string description, int roomId, string userId)
		// {
		// 	var s = new Issue(description, roomId, userId);
		// 	_manageIssue.AddIssue(s);
		// }
		
		[HttpPost]
		public void AddIssue([FromBody] IssueModel issueModel)
		{
			var s = new Issue(issueModel.Description, issueModel.RoomId, issueModel.UserId);
			_manageIssue.AddIssue(s);
		}
	}
}