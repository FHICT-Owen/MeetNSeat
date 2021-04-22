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
        public int RoomId { get; private set; }
        public int ReservationCount { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public DateTime PlannedDate { get; private set; }
        public bool IsConfirmed { get; private set; }
        #endregion Properties
        
        // Optional
        public enum Facilities
        {
            Whiteboard,
            Digitalscreen
        }

        public Reservation(int id, int roomId, int reservationCount, DateTime startTime, DateTime endTime, DateTime plannedDate, bool isConfirmed)
        {
            Id = id;
            RoomId = roomId;
            ReservationCount = reservationCount;
            StartTime = startTime;
            EndTime = endTime;
            PlannedDate = plannedDate;
            IsConfirmed = isConfirmed;
            dal = ReservationFactory.CreateReservationDal();
        }

        public Reservation(ReservationDto reservationDto)
            : this(reservationDto.Id, reservationDto.RoomId, reservationDto.ReservationCount, reservationDto.StartTime, reservationDto.EndTime, reservationDto.PlannedDate, reservationDto.IsConfirmed)
        {
        }



        public void EditReservation()
        {

        }
    }
}
