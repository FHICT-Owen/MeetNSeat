using System;

namespace MeetNSeat.Dal.Interfaces.Dtos
{
    public class ManageReservationDto
    {
        public int Id { get; }
        public int RoomId { get; }
        public string UserId { get; }
        public int FeedbackId { get; }
        public int Attendees { get; }
        public DateTime CreatedOn { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }
        public DateTime IsConfirmed { get; set; }
        public string Start { get; set; }
        public string End { get; set; }

        public ManageReservationDto(int id, int roomId, string userId, int feedbackId, int attendees, DateTime createdOn, DateTime startTime, DateTime endTime, DateTime confirmed, DateTime deletedAt, string start, string end){
            Id = id;
            RoomId = roomId;
            UserId = userId;
            FeedbackId = feedbackId;
            Attendees = attendees;
            CreatedOn = createdOn;
            StartTime = startTime;
            EndTime = endTime;
            IsConfirmed = confirmed;
            Start = start;
            End = end;
        }

        public ManageReservationDto(int id, int roomId, string userId, int feedbackId, int attendees, DateTime createdOn, DateTime startTime, DateTime endTime, DateTime confirmed, DateTime deletedAt)
        {
            Id = id;
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
