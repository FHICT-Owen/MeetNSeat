using System;
using MeetNSeat.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeetNSeat.Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var r = new IssueCollection();

			r.AddIssue(1, "s1", "YOtest");
		}
	}
	
	[TestClass]
	public class UnitTest2
	{
		[TestMethod]
		public void TestMethod1()
		{
			var r = new User();

			r.AddReservation(1, "1",5, DateTime.Now, DateTime.Now);
		}
	}
}