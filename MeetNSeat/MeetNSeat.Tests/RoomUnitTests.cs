using MeetNSeat.Dal;
using MeetNSeat.Dal.Interfaces.Dtos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeetNSeat.Tests
{
    [TestClass]
    public class RoomUnitTests
    {
        [TestMethod]
        public void Test()
        {
            var s = new RoomDal();
            s.AddNewRoom(new RoomDto(6,"TEst", "test", 4, "test"));
        }
    }
}