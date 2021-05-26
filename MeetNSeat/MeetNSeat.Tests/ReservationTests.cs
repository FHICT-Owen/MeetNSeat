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

        [TestMethod]
        public void CreateMultipleReservation()
        {
            var u = new User();

            // If reservation has been made in the past

            // If a room available with that many spots

            
        }

        //foreach (var room in rooms)
        //{
        //    if (attendees<room.Spots)
        //    {
        //        foreach (var dbReservation in dbReservations)
        //        {
        //            if (dbReservation.RoomId == room.Id &&
        //                dbReservation.StartTime<startTime && startTime<dbReservation.EndTime ||
        //                dbReservation.StartTime<endTime && endTime<dbReservation.EndTime ||
        //                dbReservation.StartTime> startTime && endTime> dbReservation.EndTime)

        //                isAvailable = false;
        //        }
        //        roomId = room.Id;
        //    }
        //}
    }
}
