using MeetNSeat.Dal.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using MeetNSeat.Dal.Interfaces.Dtos;
using System;

namespace MeetNSeat.Dal
{
    public class RoomDal : IRoomDal
    {
        public List<RoomDto> GetAllRooms()
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            var output = connection.Query<RoomDto>("dbo.GetAllRooms").ToList();
            return output;
        }

        public IReadOnlyCollection<RoomDto> GetAllRoomTypes()
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            var output = connection.Query<RoomDto>("dbo.GetAllRoomTypes").ToList();
            return output;
        }
        
        public List<RoomDto> GetAllRoomsByType(string type, int floorId)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());

            var parameters = new DynamicParameters();
            parameters.Add("@FloorId", floorId);
            parameters.Add("@RoomType", type);

            var output = connection.Query<RoomDto>("dbo.GetAllRoomsByType @RoomType, @FloorId", parameters).ToList();
            return output;
        }
        
        public void AddRoom(RoomDto roomDto)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Execute("dbo.InsertRoom @FloorId, @Name, @RoomType, @Spots, @Facilities", roomDto);
        }
        
        public void DeleteRoomById(int id)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
			
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
			
            connection.Execute("dbo.DeleteRoomById @Id", parameters);
        }
        
        public void Update(RoomDto room)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Execute("dbo.UpdateRoom @Id, @Name, @RoomType, @Spots, @Facilities", room);
        }
    }
}
