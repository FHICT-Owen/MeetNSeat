using System;
using System.ComponentModel.DataAnnotations;

namespace MeetNSeat.Dal.Interfaces
{
    public class ReservationDto
    {
        #region properties
        [Key]
        public int Id { get; }
        public int RoomId { get; }
        public string UserId { get; }
        public int FeedbackId { get; }
        public int Attendees { get; }
        public DateTime CreatedOn { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }
        public DateTime IsConfirmed { get; }
        public DateTime DeletedAt { get; }

        #endregion
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
