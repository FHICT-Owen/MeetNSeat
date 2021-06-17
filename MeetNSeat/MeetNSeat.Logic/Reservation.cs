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
        private readonly IReservationDal _dal;
        private readonly List<Reservation> _reservation = new();
        public int Id { get; private set; }
        public int RoomId { get; private set; }
        public string UserId { get; private set; }
        public int FeedbackId { get; private set; }
        public int Attendees { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public DateTime? IsConfirmed { get; private set; }
        #endregion Properties

        // Optional
        public enum Facilities
        {
            Whiteboard,
            Digitalscreen
        }

        public Reservation()
        {
            _dal = ReservationFactory.CreateReservationDal();
        }

        public Reservation(int id, int roomId, string userId, int feedbackId, int attendees, DateTime createdOn, DateTime startTime, DateTime endTime, DateTime? isConfirmed)
        {
            Id = id;
            RoomId = roomId;
            UserId = userId;
            FeedbackId = feedbackId;
            Attendees = attendees;
            CreatedOn = createdOn;
            StartTime = startTime;
            EndTime = endTime;
            IsConfirmed = isConfirmed;
            _dal = ReservationFactory.CreateReservationDal();
        }

        public Reservation(ReservationDto reservationDto)
            : this(reservationDto.Id, reservationDto.RoomId, reservationDto.UserId, reservationDto.FeedbackId, reservationDto.Attendees, reservationDto.CreatedOn, reservationDto.StartTime, reservationDto.EndTime, reservationDto.IsConfirmed)
        {
        }

        public List<ReservationDto> GetAllReservations()
        {
            return _dal.GetAllReservations();
        }

        public bool EditReservation(Reservation reservation)
        {
            var user = Authentication.Instance.GetAllUsers().SingleOrDefault(res => res.Id == reservation.UserId);
            var result = user?.GetAllReservations().SingleOrDefault(res => res.Id == reservation.Id);
            var locations = LocationCollection.Instance.GetAllLocations();
            var reservations = GetAllReservations();
            var targetRoom = new Room();
            foreach (var location in locations)
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
            if (reservation.Attendees > targetRoom.Spots) return _dal.UpdateReservation(result.ConvertToDto());
            {
                foreach (var unused in reservations.Where(res => res.RoomId == targetRoom.Id && !User.CheckForNoOverlap(res.StartTime, res.EndTime,
                    reservation.StartTime, reservation.EndTime)))
                {
                    result.Attendees = reservation.Attendees;
                    result.StartTime = reservation.StartTime;
                    result.EndTime = reservation.EndTime;
                }
            }

            return _dal.UpdateReservation(result.ConvertToDto());
        }

        public bool ConfirmReservation(string ip)
        {
            var locations = LocationCollection.Instance.GetAllLocations();
            var match = locations.Any(res => res.IpAddress == ip);
            if (!match) return false;
            return _dal.ConfirmReservation(Id, DateTime.Now);
        }

        public ReservationDto ConvertToDto()
        {
            return new(Id, RoomId, UserId, FeedbackId, Attendees, CreatedOn, StartTime, EndTime, IsConfirmed);
        }
    }
}
