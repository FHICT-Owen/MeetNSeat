using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeetNSeat.Logic;
using System.Collections.Generic;
using MeetNSeat.Dal.Interfaces.Dtos;
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
            // var u = new User();
            // u.AddReservation("Conference", 1, "108105466526811947195", 12,
            //     Convert.ToDateTime("2021-01-01T12:29"),
            //     Convert.ToDateTime("2021-01-01T17:00"));
        }

        [TestMethod]
        public void ReservationStartDateTimeInPastShouldBeFalse()
        {
            // var u = new User();
            // var actual = u.AddReservation("Conference", 1, "108105466526811947195", 12,
            //     Convert.ToDateTime("2000-01-01T00:00"),
            //     Convert.ToDateTime("3000-01-01T00:00"));
            //
            // Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ReservationEndDateTimeInPastShouldBeFalse()
        {
            // var u = new User();
            //
            // var actual = u.AddReservation("Conference", 1, "108105466526811947195", 12,
            //     Convert.ToDateTime("3000-01-01T00:00"),
            //     Convert.ToDateTime("2000-01-01T00:00"));
            //
            // Assert.IsFalse(actual);
        }

        // [TestMethod] TODO: ReservationShouldNotHaveEnoughSpots
        // public void ReservationShouldNotHaveEnoughSpots()
        // {
        //     var u = new User();
        //     
        //     var actual = u.AddReservation("Conference", 1, "108105466526811947195", 12, 
        //         Convert.ToDateTime("3000-01-01T00:00"),
        //         Convert.ToDateTime("3000-01-01T00:00"));
        //     
        //     Assert.IsFalse(actual);
        // }

        [TestMethod]
        public void CheckIfStartTimeIsBetweenAnyExistingReservation_ShouldBeFalse()
        {
            // var u = new User();
            //
            // var actual = u.AddReservation("Conference", 1, "108105466526811947195", 12,
            //     Convert.ToDateTime("2021-10-26T14:30"), //startTime
            //     Convert.ToDateTime("2021-10-26T15:30")); //endTime
            //
            // Assert.IsFalse(actual);
        }

        [TestMethod]
        public void CheckIfEndTimeIsBetweenAnyExistingReservation_ShouldBeFalse()
        {
            // var u = new User();
            //
            // var actual = u.AddReservation("Conference", 1, "108105466526811947195", 12,
            //     Convert.ToDateTime("2021-10-26T13:30"), //startTime
            //     Convert.ToDateTime("2021-10-26T14:30")); //endTime
            //
            // Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ChecksIfAnyReservationIsBetweenNewReservation_ShouldBeFalse()
        {
            // var u = new User();
            //
            // var actual = u.AddReservation("Conference", 1, "108105466526811947195", 12,
            //     Convert.ToDateTime("2021-10-26T14:15"), //startTime
            //     Convert.ToDateTime("2021-10-26T14:45")); //endTime
            //
            // Assert.IsFalse(actual);
        }

        [TestMethod]
        public void CheckIfAvailableRoomsAddedToList()
        {
            // var u = new User();
            // var locationObject = new Location();
            // var rooms = locationObject.GetAllRoomsWithType("Conference", Convert.ToInt32(21));
            // var reservationObject = new Reservation();
            // var reservations = reservationObject.GetAllReservations();
            // List<RoomDto> actual = u.GetAvailableRooms(rooms, 1, reservations,
            //     Convert.ToDateTime("2026-10-26T14:15"), //startTime
            //     Convert.ToDateTime("2026-10-26T14:45")); //endTime
            //
            // Assert.IsNotNull(actual);
        }

        #region ReservationTest
        // reservation.startTime = 14:00
        // reservation.endTime = 15:00

        // 14:00 < startTime && startTime < 15:00
        // reservation.StartTime < startTime && startTime < reservation.EndTime ||

        // 14:00 < endTime && endTime < 15:00
        // reservation.StartTime < endTime && endTime < reservation.EndTime ||

        // 14:00 > startTime && endTime > 15:00
        // reservation.StartTime > startTime && endTime > reservation.EndTime) 


        #endregion

        // var span = new TimeSpan(0,0,0, 0, 0);
        //
        // var q = DateTime.Now + span;
    }
}
