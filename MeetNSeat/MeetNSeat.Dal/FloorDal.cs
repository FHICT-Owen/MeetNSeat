using MeetNSeat.Dal.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Dal
{
    public class FloorDal : IFloorDal
    {
        public List<FloorDto> GetAllFloorsByLocation(int locationId)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@LocationID", locationId);
            var output = connection.Query<FloorDto>("dbo.GetAllFloorsByLocation, @LocationID", parameters).ToList();
            return output;
        }
    }
}
