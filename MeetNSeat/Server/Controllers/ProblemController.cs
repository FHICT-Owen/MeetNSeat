using MeetNSeat.Logic.Interfaces;
using MeetNSeat.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetNSeat.Server.Controllers
{
	public class ProblemController : ApiControllerBase
	{
		private readonly IManageProblems _manageProblems;
		public ProblemController(IManageProblems manageProblems) => _manageProblems = manageProblems;
		
		[HttpGet]
		public ActionResult GetAllProblems()
		{
			var allIssues = _manageProblems.GetAllProblems();
			return Ok(allIssues);
		}
		
		[HttpPost]
		public void AddProblem([FromBody]ProblemModel problem)
		{
			_manageProblems.AddProblem(problem.RoomId, problem.UserId, problem.Email, problem.Description, problem.Picture);
		}
		
		[HttpDelete("{id:int}")]
		public void DeleteProblem(int id)
		{
			_manageProblems.DeleteProblem(id);
		}
		
		[HttpPut]
		public void UpdateProblem([FromBody]ProblemModel problem)
		{
			if (problem.IsResolved)
			{
				
			}
			else
			{
				
			}
			_manageProblems.UpdateProblem(problem.Id, problem.RoomId, problem.UserId, problem.Email, problem.Description, problem.Picture, problem.IsResolved, problem.ResolvedAt);
		}
	}
}