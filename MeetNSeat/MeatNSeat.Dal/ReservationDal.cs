using System;
using System.Collections.Generic;
using System.Text;
using MeatNSeat.Dal.Interfaces;

namespace MeatNSeat.Dal
{
    public class ReservationDal : IReservationDal
    {
        public List<ReservationDto> GetAllReservations()
        {
            return null;
        }

        public void CreateReservation()
        {
            //Ef Insert query
        }
    }
}
