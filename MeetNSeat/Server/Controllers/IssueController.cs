using MeetNSeat.Logic;
using Microsoft.AspNetCore.Mvc;

namespace MeetNSeat.Server.Controllers
{
	[ApiController]
	public class IssueController : ControllerBase
	{
		private readonly IManageIssue _manageIssue;

		public IssueController(IManageIssue manageIssue)
		{
			_manageIssue = manageIssue;
		}
		
		[HttpGet("/api/issues")]
		public ActionResult GetAllIssues()
		{
			var issues = _manageIssue.GetAllIssues();
			return Ok(issues);
		}
	}
}