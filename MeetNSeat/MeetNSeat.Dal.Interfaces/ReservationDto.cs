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
        public int UserId { get; set; }
        public int ReservationCount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime PlannedDate { get; set; }
        public bool IsConfirmed { get; set; }
        #endregion

        public ReservationDto(int userId, int roomId, int reservationCount, DateTime startTime, DateTime endTime, DateTime plannedDate, bool isConfirmed)
        {
            RoomId = roomId;
            UserId = userId;
            ReservationCount = reservationCount;
            StartTime = startTime;
            EndTime = endTime;
            PlannedDate = plannedDate;
            IsConfirmed = isConfirmed;
        }
    }
}
