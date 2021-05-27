namespace MeetNSeat.Server.Models
{
    public class FeedbackModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        #nullable enable
        public string? Description { get; set; }
        public int? FeedbackState { get; set; }
        #nullable disable
    }
}
