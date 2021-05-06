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
        public List<RoomDto> GetAllRoomsByType(RoomDto roomDto)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString("DefaultConnection"));

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@LocationID", roomDto.LocationId);
            parameters.Add("@Type", roomDto.Type);

            var output = connection.Query<RoomDto>("dbo.GetAllRoomsByType @LocationID, @Type", parameters).ToList();
            return output;
        }
    }
}
