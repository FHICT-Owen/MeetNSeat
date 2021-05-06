using System;
using System.ComponentModel.DataAnnotations;

namespace MeetNSeat.Dal.Interfaces
{
    public class ReservationDto
    {
        #region properties
        [Key]
        public int Id { get;}
        public int RoomId { get;}
        public string UserId { get;}
        public int FeedbackId { get; }
        public int Attendees { get;}
        public DateTime CreatedOn { get;}
        public DateTime StartTime { get;}
        public DateTime EndTime { get; }
        public DateTime IsConfirmed { get; }
        #endregion


        public ReservationDto(int roomId, string userId, int attendees, DateTime startTime, DateTime endTime)
        {
            RoomId = roomId;
            UserId = userId;
            Attendees = attendees;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
