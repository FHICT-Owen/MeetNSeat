using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Dal
{
    public class UserDal : IUserDal
    {
        public List<FeedbackDto> GetFeedbackByUser(string id)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);
            var query = connection.Query<FeedbackDto>("dbo.GetFeedbackByUser @id;", parameters).ToList();
            return query;
        }
        
        public List<UserDto> GetAllUsers()
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            var output = connection.Query<UserDto>("dbo.GetAllIssues").ToList();
            return output;
        }
        
        public void AddNewUser(UserDto userDto)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Execute("dbo.InsertIssue @UserId", userDto);
        }
    }
}
