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
        public DateTime CreatedOn { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime IsConfirmed { get; set; }
        #endregion

        public ReservationDto(int id, int roomId, int userId, int attendees, DateTime createdOn, DateTime startTime, DateTime endTime, DateTime isConfirmed)
        {
            Id = id;
            RoomId = roomId;
            UserId = userId;
            Attendees = attendees;
            CreatedOn = createdOn;
            StartTime = startTime;
            EndTime = endTime;
            IsConfirmed = isConfirmed;  
        }
    }
}
