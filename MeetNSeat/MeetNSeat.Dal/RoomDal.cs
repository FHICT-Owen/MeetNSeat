using MeetNSeat.Dal.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace MeetNSeat.Dal
{
    public class RoomDal : IRoomDal
    {
        public List<RoomDto> GetAllRoomsByType(string type, int locationId)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@LocationID", locationId);
            parameters.Add("@Type", type);

            var output = connection.Query<RoomDto>("dbo.GetAllRoomsByType @LocationID, @Type", parameters).ToList();
            return output;
        }
    }
}
