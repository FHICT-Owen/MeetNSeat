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
        public void GetAllReservationsbyuser()
        {
            var u = new User();

            Assert.IsNotNull(u.GetReservationByUser("test"));
        }
        [TestMethod]
        public void GetAllReservations()
        {
            var u = new User();

            Assert.IsNotNull(u.GetAllReservations());
        }
        [TestMethod]
        public void CreateReservation()
        {
            var u = new User();
            u.AddReservation("Conference", 1, "test", 12, Convert.ToDateTime("2017-06-01T08:30"),
                Convert.ToDateTime("2017-07-01T08:30"));
        }
    }
}
