using MeetNSeat.Dal.Interfaces;

namespace MeetNSeat.Dal.Factories
{
    public class FloorFactory
    {
        public static IFloorDal CreateFloorDal()
        {
            return new FloorDal();
        }
    }
}