using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Logic.Interfaces;

namespace MeetNSeat.Logic
{
    public class User : IManageReservation
    {
        public int Id { get; set; }

        private List<Reservation> reservations = new List<Reservation>();
        private IReservationDal dal;

        public User()
        {
            // Factory
            dal = ReservationFactory.CreateReservationDal();
        }

        public void AddReservation(int roomId, string userId, int attendees, DateTime startTime, DateTime endTime)
        {
            var reservationDto = new ReservationDto(roomId, userId, attendees, DateTime.Now, startTime, endTime, DateTime.MinValue);
            dal.AddReservation(reservationDto);
        }

        public void GetAllReservations()
        {
            var reservations = dal.GetAllReservations();
        }

        public List<ReservationDto> GetReservationByUser(int userId)
        {
            return dal.GetReservationByUser(userId);
        }
    }
}
