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
        public bool DeleteFeedback(int id)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString("DefaultConnection"));
            if (connection.ExecuteScalar<bool>("EXEC DeleteFeedback", id, commandType: CommandType.StoredProcedure))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<FeedbackDto> GetAllFeedback()
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString("DefaultConnection"));
            var query = connection.Query<FeedbackDto>("EXEC GetAllFeedback", commandType: CommandType.StoredProcedure);
            List<FeedbackDto> feedback = query.ToList();
            return feedback;
        }
        public FeedbackDto GetFeedbackDtoById(int id)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString("DefaultConnection"));
            FeedbackDto feedbackDto = connection.ExecuteScalar<FeedbackDto>("EXEC GetFeedbackByID", id);
            return feedbackDto;
        }
        public bool InsertFeedback(FeedbackDto feedbackDto)
        {

            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString("DefaultConnection"));
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@Description", feedbackDto.Id);
            parameter.Add("@FeedbackState", feedbackDto.FeedbackState);
           
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
