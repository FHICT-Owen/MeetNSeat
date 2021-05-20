namespace MeetNSeat.Client.Models
{
    public class FeedbackModel
    {
        public int FeedbackId { get; set; }

        #nullable enable
        public string? Description { get; set; }
        #nullable enable
        public int? FeedbackState { get; set; }


        public FeedbackModel(string? description, int? feedbackState)
        {
            Description = description;
            FeedbackState = feedbackState;
        }
    }
}
