using MeetNSeat.Dal;
using MeetNSeat.Dal.Interfaces.Dtos;
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
            output.GetAllRoomsAndFloorByLocationId(1);
        }
        
        [TestMethod]
        public void Test1()
        {
            var output = new FloorDal();
            output.AddFloor(new FloorDto(0, "2", 1));
        }
    }
}
