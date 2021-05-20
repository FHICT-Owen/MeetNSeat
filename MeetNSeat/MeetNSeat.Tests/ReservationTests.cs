using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            u.AddReservation("Conference", 1, "108105466526811947195", 12, 
                Convert.ToDateTime("2021-01-01T12:29"),
                Convert.ToDateTime("2021-01-01T17:00"));
        }
    }
}
