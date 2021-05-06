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
		
		[HttpPost]
		public ActionResult AddIssue([FromBody] IssueModel issueModel)
		{
			var issue = new Issue(issueModel.Description, issueModel.RoomId, issueModel.UserId);
			_manageIssue.AddIssue(issue);
			return Ok($"Issue added with id: {issue.Id}");
		}
	}
}