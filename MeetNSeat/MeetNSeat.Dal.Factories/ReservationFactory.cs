using MeetNSeat.Dal.Interfaces;

namespace MeetNSeat.Dal.Factories
{
    public class ReservationFactory
    {
        public static IReservationDal CreateReservationDal()
        {
            return new ReservationDal();
        }
    }
}
