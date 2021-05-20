using System;
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

            var parameters = new DynamicParameters();
            parameters.Add("@LocationId", locationId);
            
            var output = connection.Query<FloorDto>("dbo.GetAllFloorsByLocation @LocationId", parameters).ToList();
            if (output.Count > 0) return output;
            throw new InvalidOperationException($"There's no floors at location: {locationId}"); //TODO: fix error handling
        }

        public void AddFloor(FloorDto floorDto)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Execute("dbo.InsertFloor @Name, @LocationId", floorDto);
        }
    }
}
