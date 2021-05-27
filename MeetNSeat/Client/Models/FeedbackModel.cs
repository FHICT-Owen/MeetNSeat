namespace MeetNSeat.Client.Models
{
    public class FeedbackModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        #nullable enable
        public string? Description { get; set; }
        #nullable enable
        public int? FeedbackState { get; set; }


        public FeedbackModel(string userId, string? description, int? feedbackState)
        {
            UserId = userId;
            Description = description;
            FeedbackState = feedbackState;
        }
    }
}
