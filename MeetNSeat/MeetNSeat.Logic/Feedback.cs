using MeetNSeat.Dal.Interfaces;

namespace MeetNSeat.Logic
{
    public class Feedback
    {
        public int Id { get;  }
        public string Description { get;  }
        public int FeedbackState { get;  }

        public Feedback(int id, string description, int feedbackState)
        {
            Id = id;
            Description = description;
            FeedbackState = feedbackState;
        }

        public Feedback(FeedbackDto dto)
        {
            Id = dto.Id;
            Description = dto.Description;
            FeedbackState = dto.FeedbackState;
        }

        public FeedbackDto ConvertToDto()
        {
            return new FeedbackDto(Id, Description, FeedbackState);
        }

    }
}
