using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using MeetNSeat.Dal.Interfaces;

namespace MeetNSeat.Dal
{
    public class FeedbackDal : IFeedbackDal
    {
        public bool DeleteFeedback(int feedbackID)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString("DefaultConnection"));
            if (connection.ExecuteScalar<bool>("EXEC DeleteFeedback", feedbackID, commandType: CommandType.StoredProcedure))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<FeedbackDto> getAllFeedbacks()
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString("DefaultConnection"));
            var query = connection.Query<FeedbackDto>("EXEC GetAllFeedback", commandType: CommandType.StoredProcedure);
            List<FeedbackDto> feedbacks = query.ToList();
            return feedbacks;
        }
        public FeedbackDto GetFeedbackDtoByID(int feedbackID)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString("DefaultConnection"));
            FeedbackDto feedbackDto = connection.ExecuteScalar<FeedbackDto>("EXEC GetFeedbackByID", feedbackID);
            return feedbackDto;
        }
        public bool InsertFeedback(FeedbackDto feedbackDto)
        {

            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString("DefaultConnection"));
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@Description", feedbackDto.FeedbackID);
            parameter.Add("@FeedbackState", feedbackDto.FeedbackState);
            //TODO: If statement
            if (connection.ExecuteScalar<bool>("EXEC InsertFeedback", parameter))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateFeedback(FeedbackDto feedbackDto)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString("DefaultConnection"));
            if (connection.ExecuteScalar<bool>("EXEC UpdateFeedback", feedbackDto))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
