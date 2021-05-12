namespace MeetNSeat.Dal.Interfaces
{
    public class FeedbackDto
    {
        public int FeedbackId { get; set; }
        public string? Description { get; set; }
        public int? FeedbackState { get; set; }

        public FeedbackDto(string description, int? feedbackState)
        {
            Description = description;
            FeedbackState = feedbackState;
        }
        public FeedbackDto(int feedbackId, string description, int? feedbackState)
        {
            FeedbackId = feedbackId;
            Description = description;
            FeedbackState = feedbackState;
        }

        public FeedbackDto()
        {
        }
    }
}
