﻿using System.Collections.Generic;
using MeetNSeat.Dal;
using MeetNSeat.Dal.Interfaces;

namespace MeetNSeat.Logic
{
    public class Feedback
    {
        public int FeedbackId { get; }
        public string? Description { get;  }
        public int? FeedbackState { get; }

        public Feedback(int id, string description, int feedbackState)
        {
            FeedbackId = id;
            Description = description;
            FeedbackState = feedbackState;
        }

        public Feedback(FeedbackDto dto)
        {
            FeedbackId = dto.FeedbackId;
            Description = dto.Description;
            FeedbackState = dto.FeedbackState;
        }

        public Feedback(string description, int? feedbackState)
        {
            Description = description;
            FeedbackState = feedbackState;
        }

        public FeedbackDto ConvertToDto()
        {
            return new FeedbackDto(FeedbackId, Description, FeedbackState);
        }



    }
}
