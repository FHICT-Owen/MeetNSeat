using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;

namespace MeetNSeat.Logic
{
    public class User
    {
        public int Id { get; set; }

        private List<Reservation> reservations = new List<Reservation>();
        private IReservationDal dal;

        public User()
        {
            // Factory
            dal = ReservationFactory.CreateReservationDal();
        }

        public void AddReservation(int roomId, int reservationCount, DateTime startTime, DateTime endTime, DateTime plannedDate, DateTime isConfirmed)
        {
            var reservationDto = new ReservationDto(Id, roomId, reservationCount, startTime, endTime, plannedDate, isConfirmed);
            dal.AddReservation(reservationDto);
        }
    }
}
