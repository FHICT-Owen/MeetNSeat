using MeetNSeat.Dal.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Dal
{
    public class RoomDal : IRoomDal
    {
        public List<RoomDto> GetAllRoomsByType(string type, int floorId)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());

            var parameters = new DynamicParameters();
            parameters.Add("@FloorId", floorId);
            parameters.Add("@Type", type);

            var output = connection.Query<RoomDto>("dbo.GetAllRoomsByType @Type, @FloorId", parameters).ToList();
            return output;
        }
        
        public List<RoomDto> GetAllRooms()
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            var output = connection.Query<RoomDto>("dbo.GetAllRooms").ToList();
            return output;
        }

        public void AddRoom(RoomDto roomDto)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Execute("dbo.InsertRoom @FloorId, @Name, @Type, @Spots, @Facilities", roomDto);
        }

        public IReadOnlyCollection<RoomDto> GetAllRoomTypes()
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            var output = connection.Query<RoomDto>("dbo.GetAllRoomTypes").ToList();
            return output;
        }
    }
}
