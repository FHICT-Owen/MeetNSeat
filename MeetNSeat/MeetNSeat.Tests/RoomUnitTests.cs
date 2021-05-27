using MeetNSeat.Dal;
using MeetNSeat.Dal.Interfaces.Dtos;
using MeetNSeat.Logic;
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
            s.AddRoom(new RoomDto(0, 6,"TEst", "test", 4, "test"));
        }
        
        [TestMethod]
        public void LocationWithId21ShouldBeChanged()
        {
            var s = new Floor();
            s.UpdateRoom(69, "asd", "asd", 6, "sad");
        }
    }
}