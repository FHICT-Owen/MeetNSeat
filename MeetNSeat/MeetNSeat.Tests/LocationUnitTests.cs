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
    }
}