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
            try
            {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            var output = connection.Query<RoomDto>("dbo.GetAllRooms").ToList();
            return output;
            }
            catch (SqlException ex)
            {
                throw new DalExceptions("Database cannot connect, try again!");
            }
            catch (Exception ex)
            {
                throw new DalExceptions("something went wrong");
            }
        }

        public IReadOnlyCollection<RoomDto> GetAllRoomTypes()
        {
            try {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            var output = connection.Query<RoomDto>("dbo.GetAllRoomTypes").ToList();
            return output;
            }
            catch (SqlException ex)
            {
                throw new DalExceptions("Database cannot connect, try again!");
            }
            catch (Exception ex)
            {
                throw new DalExceptions("something went wrong");
            }
        }
        
        public List<RoomDto> GetAllRoomsByType(string type, int floorId)
        {
            try
            {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());

            var parameters = new DynamicParameters();
            parameters.Add("@FloorId", floorId);
            parameters.Add("@RoomType", type);

            var output = connection.Query<RoomDto>("dbo.GetAllRoomsByType @RoomType, @FloorId", parameters).ToList();
            return output;
            }
            catch (SqlException ex)
            {
                throw new DalExceptions("Database cannot connect, try again!");
            }
            catch (Exception ex)
            {
                throw new DalExceptions("something went wrong");
            }
        }
        
        public void AddRoom(RoomDto roomDto)
        {
            try
            {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Execute("dbo.InsertRoom @FloorId, @Name, @RoomType, @Spots, @Facilities", roomDto);
            }
            catch (SqlException ex)
            {
                throw new DalExceptions("Database cannot connect, try again!");
            }
            catch (Exception ex)
            {
                throw new DalExceptions("something went wrong");
            }
        }
        
        public void DeleteRoomById(int id)
        {
            try
            {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
			
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
			
            connection.Execute("dbo.DeleteRoomById @Id", parameters);
            }
            catch (SqlException ex)
            {
                throw new DalExceptions("Database cannot connect, try again!");
            }
            catch (Exception ex)
            {
                throw new DalExceptions("something went wrong");
            }
        }
        
        public void Update(RoomDto room)
        {
            try
            {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Execute("dbo.UpdateRoom @Id, @Name, @RoomType, @Spots, @Facilities", room);
            }
            catch (SqlException ex)
            {
                throw new DalExceptions("Database cannot connect, try again!");
            }
            catch (Exception ex)
            {
                throw new DalExceptions("something went wrong");
            }
        }
    }
}
