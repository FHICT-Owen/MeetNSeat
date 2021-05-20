using MeetNSeat.Dal.Interfaces;

namespace MeetNSeat.Dal.Factories
{
    public static class LocationFactory
    {
        public static ILocationDal CreateIssueDal()
        {
            return new LocationDal();
        }
    }
}