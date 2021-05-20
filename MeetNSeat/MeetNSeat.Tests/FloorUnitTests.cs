using System;
using System.Collections.Generic;
using MeetNSeat.Dal;
using MeetNSeat.Dal.Interfaces.Dtos;
using MeetNSeat.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeetNSeat.Tests
{
    [TestClass]
    public class FloorUnitTests
    {
        [TestMethod]
        public void Test()
        {
            var output = new FloorDal();
            output.GetAllFloorsByLocationId(4);
        }
        
        [TestMethod]
        public void Test1()
        {
            var output = new FloorDal();
            output.AddFloor(new FloorDto(0, "2", 4));
        }
    }
}
