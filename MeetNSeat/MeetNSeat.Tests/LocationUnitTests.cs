using MeetNSeat.Dal;
using MeetNSeat.Dal.Interfaces.Dtos;
using MeetNSeat.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MeetNSeat.Tests
{
    [TestClass]
    public class LocationUnitTests
    {
        [TestMethod]
        public void Test()
        {
            var s = new LocationDal();
            s.AddLocation(new LocationDto(0, "Test", "Eindhoven", "0"));
        }
        
        [TestMethod]
        public void Test1()
        {
            var s = new LocationCollection();
            s.GetAllLocations();
        }

        [TestMethod]
        public void Test2()
        {
            var s = new Location();
            s.GetAllRoomsWithType("Conference", 1);
        }
        
        [TestMethod]
        public void Test3()
        {
            var s = new Location();
            s.GetAllRoomsAndFloorByLocationId(21);
        }
        
        [TestMethod]
        public void LocationWithId21ShouldBeChanged()
        {
            var s = new Location();
            s.Update(21, "Building 1", "Eindhoven", "Test changed ip");
        }
        
        [TestMethod]
        public void LocationWithId24ShouldBeDeleted()
        {
            var s = new LocationCollection();
            s.DeleteLocation(24);
        }
    }
}