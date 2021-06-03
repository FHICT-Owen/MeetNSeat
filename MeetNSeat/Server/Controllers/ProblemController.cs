using MeetNSeat.Logic.Interfaces;
using MeetNSeat.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetNSeat.Server.Controllers
{
	public class ProblemController : ApiControllerBase
	{
		private readonly IManageProblems _manageProblems;

		public ProblemController(IManageProblems manageProblems)
		{
			_manageProblems = manageProblems;
		}
		
		[HttpGet]
		public ActionResult GetAllProblems()
		{
			var allIssues = _manageProblems.GetAllProblems();
			return Ok(allIssues);
		}
		
		[HttpPost]
		public void AddProblem([FromBody] ProblemModel problemModel)
		{
			_manageProblems.AddProblem(problemModel.RoomId, problemModel.UserId, problemModel.Email, problemModel.Description, problemModel.Picture);
		}
		
		[HttpDelete("{id:int}")]
		public void DeleteProblem(int id)
		{
			_manageProblems.DeleteProblem(id);
		}
		
		[HttpPut]
		public void UpdateProblem([FromBody] ProblemModel problemModel)
		{
			_manageProblems.UpdateProblem(problemModel.Id, problemModel.RoomId, problemModel.UserId, problemModel.Email, problemModel.Description, problemModel.Picture, problemModel.IsResolved, problemModel.ResolvedAt);
		}
	}
}