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
    public class UserDal : IUserDal
    {
        public List<FeedbackDto> GetFeedbackByUser(string id)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString("DefaultConnection"));
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);
            var query = connection.Query<FeedbackDto>("dbo.GetFeedbackByUser @id;", parameters).ToList();
            return query;
        }
    }
}
