using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MeatNSeat.Dal.Factories;
using MeatNSeat.Dal.Interfaces;

namespace MeetNSeat.Shared
{
    public class User
    {
        private List<Reservation> reservations = new List<Reservation>();
        private IReservationDal dal;

        public User()
        {
            // Factory
            dal = ReservationFactory.CreateReservationDal();
        }
        

        public void AddReservation()
        {
            Reservation reservation = new Reservation();


        }
    }
}
