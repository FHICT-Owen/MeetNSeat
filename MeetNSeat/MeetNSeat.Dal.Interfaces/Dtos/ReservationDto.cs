using System;
using System.ComponentModel.DataAnnotations;

namespace MeetNSeat.Dal.Interfaces.Dtos
{
    public class ReservationDto
    {
        #region properties
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string UserId { get; set; }
        public int FeedbackId { get; set; }
        public int Attendees { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime IsConfirmed { get; set; }
        public DateTime DeletedAt { get; set; }
        #endregion

        public ReservationDto() { }
        public ReservationDto(
            int reservationId, int roomId, string userId, int feedbackId, int attendees, DateTime createdOn, DateTime startTime, DateTime endTime, DateTime confirmed
        )
        {
            Id = reservationId;
            RoomId = roomId;
            UserId = userId;
            FeedbackId = feedbackId;
            Attendees = attendees;
            StartTime = startTime;
            EndTime = endTime;
            CreatedOn = createdOn;
            IsConfirmed = confirmed;
        }

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
