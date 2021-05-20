using System;
using System.Collections.Generic;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Logic
{
    public class Reservation
    {
        #region Properties
        private readonly IReservationDal dal;
        private readonly List<Reservation> _reservation = new List<Reservation>();
        public int ReservationId { get; private set; }
        public int RoomId { get; private set; }
        public string UserId { get; private set; }
        public int FeedbackId { get; private set; }
        public int Attendees { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public DateTime IsConfirmed { get; private set; }
        public DateTime DeletedAt { get; private set; }
        #endregion Properties

        // Optional
        public enum Facilities
        {
            Whiteboard,
            Digitalscreen
        }

        public Reservation()
        {
            dal = ReservationFactory.CreateReservationDal();
        }

        public Reservation(int reservationid, int roomId, string userId, int feedbackId, int attendees, DateTime createdOn, DateTime startTime, DateTime endTime, DateTime isConfirmed)
        {
            ReservationId = reservationid;
            RoomId = roomId;
            UserId = userId;
            FeedbackId = feedbackId;
            Attendees = attendees;
            CreatedOn = createdOn;
            StartTime = startTime;
            EndTime = endTime;
            IsConfirmed = isConfirmed;
            dal = ReservationFactory.CreateReservationDal();
        }

        public Reservation(ManageReservationDto reservationDto)
            : this(reservationDto.ReservationId, reservationDto.RoomId, reservationDto.UserId, reservationDto.FeedbackId, reservationDto.Attendees, reservationDto.CreatedOn, reservationDto.StartTime, reservationDto.EndTime, reservationDto.IsConfirmed)
        {
        }

        public List<ManageReservationDto> GetAllReservations()
        {
            return dal.GetAllReservations();
        }

        public void ConfirmReservation(int id)
        {
            IsConfirmed = DateTime.Now;
            dal.ConfirmReservation(id, IsConfirmed);
        }

        public bool EditReservation(Reservation reservation)
        {
            _reservation.Add(reservation);
           return dal.UpdateReservation(reservation.ConvertToDto());
        }
        public ReservationDto ConvertToDto()
        {
            return new(ReservationId, RoomId, UserId, FeedbackId, Attendees, CreatedOn, StartTime, EndTime, IsConfirmed);
        }
    }
}
