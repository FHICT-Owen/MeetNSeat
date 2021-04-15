using System;
using System.Collections.Generic;
using System.Text;
using MeatNSeat.Dal.Interfaces;

namespace MeatNSeat.Dal.Factories
{
    public class ReservationFactory
    {
        public static IReservationDal CreateReservationDal()
        {
            return new ReservationDal();
        }
    }
}
