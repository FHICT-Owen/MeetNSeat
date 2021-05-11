using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeetNSeat.Dal;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Logic;
namespace MeetNSeat.Tests
{
    [TestClass]
    public class ReservationsTests
    {
        [TestMethod]
        public void GetAllReservations()
        {
            var u = new User();

            Assert.IsNotNull(u.GetReservationByUser("test"));
        }
    }
}
