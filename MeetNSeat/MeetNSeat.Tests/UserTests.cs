using System;
using System.Linq;
using MeetNSeat.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeetNSeat.Tests
{
    [TestClass]
    public class UserTests
    {
        private readonly DateTime _dbStart = Convert.ToDateTime("2021-01-01T12:00");// 12:00
        private readonly DateTime _dbEnd = Convert.ToDateTime("2021-01-01T12:30");  // 12:30
        
        //[TestMethod]
        //public void ReservationAfterDbReservation_ShouldReturnTrue()
        //{
        //    var resStart = Convert.ToDateTime("2021-01-01T12:30");  // res: 12:30 | db: 12:00
        //    var resEnd = Convert.ToDateTime("2021-01-01T13:00");    // res: 13:00 | db: 12:30
            
        //    var actual = new User().CheckForNoOverlap(_dbStart, _dbEnd, resStart, resEnd);

        //    Assert.IsTrue(actual);
        //}
        
        //[TestMethod]
        //public void ReservationBeforeDbReservation_ShouldReturnTrue()
        //{
        //    var resStart = Convert.ToDateTime("2021-01-01T11:30");  // res: 11:30 | db: 12:00
        //    var resEnd = Convert.ToDateTime("2021-01-01T12:00");    // res: 12:00 | db: 12:30
            
        //    var actual = new User().CheckForNoOverlap(_dbStart, _dbEnd, resStart, resEnd);

        //    Assert.IsTrue(actual);
        //}
        
        //[TestMethod]
        //public void DbReservationWithinReservation_ShouldReturnFalse()
        //{
        //    var resStart = Convert.ToDateTime("2021-01-01T11:30");  // res: 11:30 | db: 12:00
        //    var resEnd = Convert.ToDateTime("2021-01-01T13:00");    // res: 13:00 | db: 12:30
            
        //    var actual = new User().CheckForNoOverlap(_dbStart, _dbEnd, resStart, resEnd);

        //    Assert.IsFalse(actual);
        //}
        
        //[TestMethod]
        //public void DbReservationOverlappingWithReservation_ShouldReturnFalse()
        //{
        //    var resStart = Convert.ToDateTime("2021-01-01T12:15");  // res: 12:15 | db: 12:00
        //    var resEnd = Convert.ToDateTime("2021-01-01T13:00");    // res: 13:00 | db: 12:30
            
        //    var actual = new User().CheckForNoOverlap(_dbStart, _dbEnd, resStart, resEnd);

        //    Assert.IsFalse(actual);
        //}

        [TestMethod]
        public void GetAllUsers()
        {
            Assert.IsTrue(Authentication.Instance.GetAllUsers().Any());
        }
    }
}