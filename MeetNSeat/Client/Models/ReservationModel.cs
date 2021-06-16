﻿using System;

namespace MeetNSeat.Client.Models
{
    public class ReservationModel
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int LocationId { get; set; }
        public string Type { get; set; }
        public string UserId { get; set; }
        public int FeedbackId { get; set; }
        public int Attendees { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime? IsConfirmed { get; set; }
        public DateTime DeletedAt { get; set; }

        public ReservationModel()
        {
            
        }

        public ReservationModel(ReservationModel reservation)
        {
            Id = reservation.Id;
            RoomId = reservation.RoomId;
            LocationId = reservation.LocationId;
            Type = reservation.Type;
            UserId = reservation.UserId;
            FeedbackId = reservation.FeedbackId;
            Attendees = reservation.Attendees;
            CreatedOn = reservation.CreatedOn;
            StartTime = reservation.StartTime;
            EndTime = reservation.EndTime;
            IsConfirmed = reservation.IsConfirmed;
            DeletedAt = reservation.DeletedAt;
        }

        public ReservationModel(int id, int roomId, int locationId, string type, string userId, int feedbackId, int attendees, DateTime createdOn, DateTime startTime, DateTime endTime, DateTime? isConfirmed, DateTime deletedAt)
        {
            Id = id;
            RoomId = roomId;
            LocationId = locationId;
            Type = type;
            UserId = userId;
            FeedbackId = feedbackId;
            Attendees = attendees;
            CreatedOn = createdOn;
            StartTime = startTime;
            EndTime = endTime;
            IsConfirmed = isConfirmed;
            DeletedAt = deletedAt;
        }

        public ReservationModel(int id, int roomId, string userId, int feedbackId, int attendees, DateTime createdOn, DateTime startTime, DateTime endTime, DateTime? isConfirmed, DateTime deletedAt)
        {
            Id = id;
            RoomId = roomId;
            UserId = userId;
            FeedbackId = feedbackId;
            Attendees = attendees;
            CreatedOn = createdOn;
            StartTime = startTime;
            EndTime = endTime;
            IsConfirmed = isConfirmed;
            DeletedAt = deletedAt;
        }

        public ReservationModel(int id, int roomId, string userId, int feedbackId, int attendees, DateTime createdOn, DateTime startTime, DateTime endTime)
        {
            Id = id;
            RoomId = roomId;
            UserId = userId;
            FeedbackId = feedbackId;
            Attendees = attendees;
            CreatedOn = createdOn;
            StartTime = startTime;
            EndTime = endTime;
        }

        public ReservationModel(int locationId, string type, string userId, int attendees, DateTime startTime, DateTime endTime)
        {
            LocationId = locationId;
            Type = type;
            UserId = userId;
            Attendees = attendees;
            StartTime = startTime;
            EndTime = endTime;
        }
        public ReservationModel(int locationId,int roomId, string type, string userId, int attendees, DateTime startTime, DateTime endTime)
        {
            LocationId = locationId;
            RoomId = roomId;
            Type = type;
            UserId = userId;
            Attendees = attendees;
            StartTime = startTime;
            EndTime = endTime;
        }
        public ReservationModel(int id, int roomId, int attendees, DateTime startTime, DateTime endTime)
        {
            Id = id;
            RoomId = roomId;
            Attendees = attendees;
            StartTime = startTime;
            EndTime = endTime;
        }

        public ReservationModel(int roomId, int locationId, string type, int attendees, DateTime startTime, DateTime endTime)
        {
            
            RoomId = roomId;
            LocationId = locationId;
            Type = type;
            Attendees = attendees;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
