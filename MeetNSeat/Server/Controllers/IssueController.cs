using MeetNSeat.Logic;
using MeetNSeat.Logic.Interfaces;
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
			var allIssues = _manageIssue.GetAllIssues();
			return Ok(allIssues);
		}
		
		[HttpPost]
		public void AddIssue([FromBody] IssueModel issueModel)
		{
			var newIssue = new Issue(issueModel.Description, issueModel.RoomId, issueModel.UserId);
			_manageIssue.AddIssue(newIssue);
		}
	}
}