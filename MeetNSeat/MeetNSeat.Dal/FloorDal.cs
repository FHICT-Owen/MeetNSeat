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
        public List<FloorDto> GetAllRoomsAndFloorByLocationId(int id)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            
            var output = connection.Query<FloorDto>("dbo.GetRoomByFloorIdAndGetFloorByLocationId @Id", parameters).ToList();
            return output;
        }

        public void AddFloor(FloorDto floorDto)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Execute("dbo.InsertFloor @Name, @LocationId", floorDto);
        }
    }
}
