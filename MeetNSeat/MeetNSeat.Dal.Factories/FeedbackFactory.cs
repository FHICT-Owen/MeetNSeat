using MeetNSeat.Dal.Interfaces;

namespace MeetNSeat.Dal.Factories
{
    public class FeedbackFactory
    {
        public static IFeedbackDal CreateFeedbackDal()
        {
            return new FeedbackDal();
        }
    }
}
