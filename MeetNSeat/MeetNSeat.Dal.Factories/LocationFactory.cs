using MeetNSeat.Dal.Interfaces;

namespace MeetNSeat.Dal.Factories
{
    public static class LocationFactory
    {
        public static ILocationDal CreateLocationDal()
        {
            return new LocationDal();
        }
    }
}