using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeetNSeat.Dal;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Logic;
namespace MeetNSeat.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var r = new User();

            r.AddReservation(1, 5, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);
        }
    }
}
