using System;
using MeetNSeat.Dal;
using MeetNSeat.Dal.Interfaces.Dtos;
using MeetNSeat.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeetNSeat.Tests
{
	[TestClass]
	public class ProblemUnitTests
	{
		private readonly ProblemCollection _problemCollection = new();
		
		[TestMethod]
		public void ProblemShouldBeAddedToTheDatabase()
		{
			// _issueCollection.AddIssue("Test succeeded", 1, "test");
		}
		
		[TestMethod]
		public void AllProblemsShouldBeRetrievedFromDatabase()
		{
			var output = _problemCollection.GetAllProblems();
		}
		
		[TestMethod]
		public void ProblemWithIdShouldBeResolved()
		{
			var issue = new ProblemDal();
			// issue.Update(new IssueDto(27, 1, "108105466526811947195", "", DateTime.Now, true));
		}
	}
}