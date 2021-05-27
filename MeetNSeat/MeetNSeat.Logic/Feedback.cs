using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Logic
{
    public class Feedback
    {
        public int FeedbackId { get; }

        public string UserId { get; }
        #nullable enable
        public string? Description { get;  }
        public int? FeedbackState { get; }
        #nullable disable
        
        public Feedback(int id, string userId, string description, int feedbackState)
        {
            FeedbackId = id;
            UserId = userId;
            Description = description;
            FeedbackState = feedbackState;
        }

        public Feedback(FeedbackDto dto)
        {
            FeedbackId = dto.Id;
            UserId = dto.UserId;
            Description = dto.Description;
            FeedbackState = dto.FeedbackState;
        }

        public Feedback(string description, int? feedbackState, string userId)
        {
            Description = description;
            FeedbackState = feedbackState;
            UserId = userId;
        }

        public FeedbackDto ConvertToDto()
        {
            return new FeedbackDto(FeedbackId, UserId , Description, FeedbackState);
        }
    }
}
