namespace MeetNSeat.Logic
{
    public class Feedback
    {
        public int Id { get; private set; }
        public string Description { get; private set; }
        public int FeedbackState { get; private set; }

        public Feedback(int id, string description, int feedbackState)
        {
            Id = id;
            Description = description;
            FeedbackState = feedbackState;
        }

    }
}
