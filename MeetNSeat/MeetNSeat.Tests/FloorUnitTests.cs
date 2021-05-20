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
            output.GetAllFloorsByLocation(2);
        }
    }
}
