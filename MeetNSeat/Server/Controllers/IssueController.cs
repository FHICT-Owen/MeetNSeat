using MeetNSeat.Logic.Interfaces;
using MeetNSeat.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetNSeat.Server.Controllers
{
	public class IssueController : ApiControllerBase
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
			_manageIssue.AddIssue(issueModel.RoomId, issueModel.UserId, issueModel.Email, issueModel.Description, issueModel.Picture);
		}
		
		[HttpDelete("{id:int}")]
		public void DeleteIssue(int id)
		{
			_manageIssue.DeleteIssue(id);
		}
		
		[HttpPut]
		public void UpdateIssue([FromBody] IssueModel issueModel)
		{
			_manageIssue.UpdateIssue(issueModel.Id, issueModel.RoomId, issueModel.UserId, issueModel.Email, issueModel.Description, issueModel.Picture, issueModel.IsResolved, issueModel.ResolvedAt);
		}
	}
}