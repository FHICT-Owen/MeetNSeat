namespace MeetNSeat.Dal.Interfaces.Dtos
{
    public class FeedbackDto
    {
        public int Id { get; set; }
        #nullable enable
        public string? Description { get; set; }
        public int? FeedbackState { get; set; }
        #nullable disable

        public FeedbackDto() { }
        public FeedbackDto(string description, int? feedbackState)
        {
            Description = description;
            FeedbackState = feedbackState;
        }
        public FeedbackDto(int id, string description, int? feedbackState)
        {
            Id = id;
            Description = description;
            FeedbackState = feedbackState;
        }
    }
}
