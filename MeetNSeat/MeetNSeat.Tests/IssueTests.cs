using System;
using MeetNSeat.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeetNSeat.Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void IssueShouldBeAddedToTheDatabase()
		{
			var issueCollection = new IssueCollection();

			issueCollection.AddIssue(1, "test", "Test succeeded");
		}
	}
}