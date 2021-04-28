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
        public int UserId { get; set; }

        private List<Reservation> reservations = new List<Reservation>();
        private IReservationDal dal;

        public User()
        {
            // Factory
            dal = ReservationFactory.CreateReservationDal();
        }
        public void AddReservation(int id, int roomId, int userId, int attendees, DateTime createdOn, DateTime startTime, DateTime endTime, DateTime isConfirmed)
        {
            var reservationDto = new ReservationDto(id, roomId, userId,  attendees, createdOn, startTime, endTime, isConfirmed);
            dal.AddReservation(reservationDto);
        }
    }
}
