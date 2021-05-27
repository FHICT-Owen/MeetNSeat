using System;
using System.Collections.Generic;
using System.Linq;
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
            : this(reservationDto.Id, reservationDto.RoomId, reservationDto.UserId, reservationDto.FeedbackId, reservationDto.Attendees, reservationDto.CreatedOn, reservationDto.StartTime, reservationDto.EndTime, reservationDto.IsConfirmed)
        {
        }

        public List<ManageReservationDto> GetAllReservations()
        {
            return dal.GetAllReservations();
        }

        public bool EditReservation(Reservation reservation)
        {
            var user = Authentication.Instance.GetAllUsers().SingleOrDefault(res => res.Id == reservation.UserId);
            var result = user?.GetAllReservations().SingleOrDefault(res => res.ReservationId == reservation.ReservationId);
            var Locations = LocationCollection.Instance.GetAllLocations();
            var reservations = GetAllReservations();
            var targetRoom = new Room();
            foreach (var location in Locations)
            {
                var floors = location.GetAllFloors();
                foreach (var floor in floors)
                {
                    var room = floor.GetAllRooms().SingleOrDefault(res => res.Id == reservation.RoomId);
                    if (room == null) return false;
                    targetRoom = room;
                }
            }
            if (result == null) return false;
            if (reservation.Attendees <= targetRoom.Spots)
                foreach (var res in reservations)
                    if (res.RoomId == targetRoom.Id &&
                        res.StartTime < reservation.StartTime && reservation.StartTime < res.EndTime ||
                        res.StartTime < reservation.EndTime && reservation.EndTime < res.EndTime ||
                        res.StartTime > reservation.StartTime && reservation.EndTime > res.EndTime)
                    {
                        result.Attendees = reservation.Attendees;
                        result.StartTime = reservation.StartTime;
                        result.EndTime = reservation.EndTime;
                    }
            return dal.UpdateReservation(result.ConvertToDto());
        }

        public void ConfirmReservation(int id)
        {
            IsConfirmed = DateTime.Now;
            dal.ConfirmReservation(id, IsConfirmed);
        }

        public ReservationDto ConvertToDto()
        {
            return new(ReservationId, RoomId, UserId, FeedbackId, Attendees, CreatedOn, StartTime, EndTime, IsConfirmed);
        }
    }
}
