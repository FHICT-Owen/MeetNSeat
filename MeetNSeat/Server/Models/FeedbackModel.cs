namespace MeetNSeat.Server.Models
{
    public class FeedbackModel
    {
        public int FeedbackId { get; set; }
        #nullable enable
        public string? Description { get; set; }

        #nullable enable
        public int? FeedbackState { get; set; }

    }
}
