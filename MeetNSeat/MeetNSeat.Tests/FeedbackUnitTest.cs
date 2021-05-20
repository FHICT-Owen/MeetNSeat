using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MeetNSeat.Dal;
using MeetNSeat.Dal.Interfaces.Dtos;
using MeetNSeat.Logic;

namespace MeetNSeat.Tests
{
    [TestClass]
    public class FeedbackUnitTest
    {
        private FeedbackDal feedbackDal = new FeedbackDal();
        [TestMethod]
        public void GetAllFeedbackTest()
        {
            List<FeedbackDto> feedbackDals = feedbackDal.GetAllFeedback();
            Assert.IsNotNull(feedbackDals, "Feedack is not null");
        }

        [TestMethod]
        public void GetFeedbackDtoByIdTest()
        {
            int feedbackDto = feedbackDal.GetFeedbackDtoById(6).Id;
            Assert.AreEqual(2, feedbackDto, "Feedback by Id returns a feedback");

        }

        [TestMethod]
        public void InsertFeedbackTest()
        {
            FeedbackDto feedbackDto = new FeedbackDto("This is the description",1);
            bool result = feedbackDal.InsertFeedback(feedbackDto);
            Assert.IsTrue(result, "Success InsertFeedbackTest");
        }

        [TestMethod]
        public void UpdateFeedback()
        {
            FeedbackDto feedbackDto = new FeedbackDto(3,"This is the description", 2);
            bool result = feedbackDal.UpdateFeedback(feedbackDto);
            Assert.IsTrue(result, "Success");
        }

        [TestMethod]
        public void DeleteFeedbackTest()
        {
            bool result = feedbackDal.DeleteFeedback(4);

            Assert.IsTrue(result, "successfully deleted");
        }

        [TestMethod]
        public void GetFeedbackByUser()
        {
            UserDal userDal = new UserDal();
            FeedbackCollection feedback = new FeedbackCollection();
            List<FeedbackDto> feedbackDto = feedback.GetFeedbackByUser("Rik Leemans");
            Assert.IsNotNull(feedbackDto);
        }
    }
}
