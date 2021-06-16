namespace MeetNSeat.Dal.Interfaces.Dtos
{
    public class FeedbackDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        #nullable enable
        public string? Description { get; set; }
        public int? FeedbackState { get; set; }
        #nullable disable

        public FeedbackDto()
        {

        }

        public FeedbackDto(string description, int? feedbackState)
        {
            Description = description;
            FeedbackState = feedbackState;
        }

        public FeedbackDto(int id, string userId, string? description, int? feedbackState)
        {
            Id = id;
            UserId = userId;
            Description = description;
            FeedbackState = feedbackState;
        }
    }
}
