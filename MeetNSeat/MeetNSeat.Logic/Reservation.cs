using System;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;

namespace MeetNSeat.Logic
{
    public class Reservation
    {
        #region Properties
        private readonly IReservationDal dal;
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public int RoomId { get; private set; }
        public int Attendees { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public DateTime IsConfirmed { get; private set; }
        #endregion Properties
        
        // Optional
        public enum Facilities
        {
            Whiteboard,
            Digitalscreen
        }

        public Reservation(int id, int userId, int roomId, int attendees, DateTime startTime, DateTime endTime, DateTime isConfirmed)
        {
            Id = id;
            UserId = userId;
            RoomId = roomId;
            Attendees = attendees;
            StartTime = startTime;
            EndTime = endTime;
            IsConfirmed = isConfirmed;
            dal = ReservationFactory.CreateReservationDal();
        }

        public Reservation(ReservationDto reservationDto)
            : this(reservationDto.Id, reservationDto.UserId, reservationDto.RoomId, reservationDto.Attendees, reservationDto.StartTime, reservationDto.EndTime, reservationDto.IsConfirmed)
        {
        }



        public void EditReservation()
        {

        }
    }
}
