using Dapper;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Dal.Interfaces.Dtos;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MeetNSeat.Dal
{
    public class FloorDal : IFloorDal
    {
        public List<FloorDto> GetAllFloorsByLocation(int locationId)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@LocationId", locationId);
            var output = connection.Query<FloorDto>(@"dbo.GetAllFloorsByLocation, @LocationId", parameters).ToList();
            return output;
        }

        public void AddFloor(FloorDto floorDto)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Execute("dbo.InsertFloor @Name, @LocationId", floorDto);

        }
    }
}
