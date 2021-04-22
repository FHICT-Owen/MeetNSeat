using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MeetNSeat.Dal.Interfaces
{
    public class ReservationDto
    {
        #region properties
        [Key]
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int ReservationCount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime PlannedDate { get; set; }
        public bool IsConfirmed { get; set; }
        #endregion

        public ReservationDto(int id, int roomId, int reservationCount, DateTime startTime, DateTime endTime, DateTime plannedDate, bool isConfirmed)
        {
            Id = id;
            RoomId = roomId;
            ReservationCount = reservationCount;
            StartTime = startTime;
            EndTime = endTime;
            PlannedDate = plannedDate;
            IsConfirmed = isConfirmed;
        }
    }
}
