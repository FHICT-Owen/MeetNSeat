using Dapper;
using MeetNSeat.Dal.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MeetNSeat.Dal
{
    public class FeedbackDal : IFeedbackDal
    {
        public bool DeleteFeedback(int id)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@id", id);
            var result = connection.Execute("dbo.DeleteFeedback @id", parameter);
            if (result > 0)
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
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            var query = connection.Query<FeedbackDto>("dbo.GetAllFeedback;").ToList();
            return query;
        }
        public FeedbackDto GetFeedbackDtoById(int id)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@id", id);
            var feedbackDto = connection.Query<FeedbackDto>(@"dbo.GetFeedbackByID @id;", parameter).First();
            return feedbackDto;
        }
        public bool InsertFeedback(FeedbackDto feedbackDto)
        {

            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@Description", feedbackDto.Description);
            parameter.Add("@FeedbackState", feedbackDto.FeedbackState);
            var result  = connection.Execute("dbo.InsertFeedback @Description, @FeedbackState", feedbackDto);
            if (result > 0)
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
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@id", feedbackDto.Id);
            parameter.Add("@description", feedbackDto.Description);
            parameter.Add("@feedbackstate", feedbackDto.FeedbackState);

            var result = connection.Execute("dbo.UpdateFeedback @id, @description, @feedbackstate", feedbackDto);
            if (result > 0)
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
