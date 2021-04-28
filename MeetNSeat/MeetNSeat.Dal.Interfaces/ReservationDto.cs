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
        public int Attendees { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime PlannedDate { get; set; }
        public DateTime IsConfirmed { get; set; }
        #endregion

        public ReservationDto(int userId, int roomId, int attendees, DateTime startTime, DateTime endTime, DateTime plannedDate, DateTime isConfirmed)
        {
            RoomId = roomId;
            UserId = userId;
            Attendees = attendees;
            StartTime = startTime;
            EndTime = endTime;
            PlannedDate = plannedDate;
            IsConfirmed = isConfirmed;
        }
    }
}
