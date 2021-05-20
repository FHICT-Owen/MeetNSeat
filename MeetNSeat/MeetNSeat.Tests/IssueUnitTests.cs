using MeetNSeat.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeetNSeat.Tests
{
	[TestClass]
	public class IssueUnitTests
	{
		private readonly IssueCollection _issueCollection = new();
		
		[TestMethod]
		public void IssueShouldBeAddedToTheDatabase()
		{
			_issueCollection.AddIssue("Test succeeded", 1, "test");
		}
		
		[TestMethod]
		public void AllIssuesShouldBeRetrievedFromDatabase()
		{
			var output = _issueCollection.GetAllIssues();
		}
		
		[TestMethod]
		public void IssueWithIdShouldBeResolved()
		{
			// _issueCollection.GetAllIssues();
			// _issueCollection.
		}
	}
}