using System;
using MeetNSeat.Logic.Interfaces;

namespace MeetNSeat.Logic.Factories
{
    public class ReservationFactory
    {
        public static IManageReservation AddReservation()
        {
            return new User();
        }
    }
}
