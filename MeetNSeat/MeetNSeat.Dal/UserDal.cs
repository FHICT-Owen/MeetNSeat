using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            var query = connection.Query<FeedbackDto>("dbo.GetFeedbackByUser @Id", parameters).ToList();
            return query;
        }

        public int CheckRole(string id)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            var query = connection.Query<int>("dbo.CheckRole @Id", parameters);
            var val = query.FirstOrDefault();
            return val;
        }
        
        public List<UserDto> GetAllUsers()
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            var output = connection.Query<UserDto>("dbo.GetAllUsers").ToList();
            return output;
        }
        
        public void AddNewUser(UserDto userDto)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Execute("dbo.InsertUser @Id, @Nickname, @RoleId", userDto);
        }
    }
}
