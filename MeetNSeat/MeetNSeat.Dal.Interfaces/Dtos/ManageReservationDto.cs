﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MeetNSeat.Dal.Interfaces.Dtos
{
    public class ManageReservationDto
    {
        public int ReservationId { get; }
        public int RoomId { get; }
        public string UserId { get; }
        public int FeedbackId { get; }
        public int Attendees { get; }
        public DateTime CreatedOn { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }
        public DateTime IsConfirmed { get; set; }

        public ManageReservationDto(int reservationId, int roomId, string userId, int feedbackId, int attendees, DateTime createdOn, DateTime startTime, DateTime endTime, DateTime confirmed, DateTime deletedAt){
            ReservationId = reservationId;
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