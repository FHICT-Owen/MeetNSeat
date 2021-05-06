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


        public ReservationDto(int reservationId, int roomId, string userId, int feedbackId, int attendees, DateTime createdOn, DateTime startTime, DateTime endTime, DateTime confirmed)
        {
            Id = reservationId;
            RoomId = roomId;
            UserId = userId;
            FeedbackId = feedbackId;
            Attendees = attendees;
            CreatedOn = createdOn;
            StartTime = startTime;
            EndTime = endTime;
            IsConfirmed = confirmed;
        }
    }
}
