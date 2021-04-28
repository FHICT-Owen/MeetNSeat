using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeetNSeat.Dal;
using MeetNSeat.Dal.Interfaces;

namespace MeetNSeat.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var r = new ReservationDal();

            var reservationDto = new ReservationDto(1, 1, 5,DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);

            r.AddReservation(reservationDto);
        }
    }
}
