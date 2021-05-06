using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Logic.Interfaces;
using System;
using System.Collections.Generic;

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

       

        public List<ReservationDto> GetAllReservations()
        {
            return dal.GetAllReservations();
            
        }

        public List<ReservationDto> GetReservationByUser(int userId)
        {
            return dal.GetReservationByUser(userId);
        }

        public void AddReservation(int roomId, string userId, int feedbackId, int attendees, DateTime startTime, DateTime endTime)
        {
            // TODO: Kamers ophalen gebaseerd op type.
            

            throw new NotImplementedException();
        }
    }
}
