using Dapper;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Dal.Interfaces.Dtos;
using System;
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
            try
            {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            
            var lookup = new Dictionary<int, FloorDto>();
            
            connection.Query<FloorDto, RoomDto, FloorDto>("dbo.GetRoomByFloorIdAndGetFloorByLocationId @Id", param: parameters, map:(f, r) =>
            {
                FloorDto floor;
                if (!lookup.TryGetValue(f.Id, out floor))
                    lookup.Add(f.Id, floor = f);

                if (floor.Rooms == null)
                    floor.Rooms = new List<RoomDto>();

                floor.Rooms.Add(r);

                return floor;

            }).AsQueryable();

            var output = lookup.Values.ToList();
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

        public List<FloorDto> GetAllFloors()
        {
            try
            {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            var output = connection.Query<FloorDto>("dbo.GetAllFloors").ToList();
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

        public void AddFloor(FloorDto floorDto)
        {
            try
            {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Execute("dbo.InsertFloor @Name, @LocationId", floorDto);
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

        public void DeleteFloorById(int id)
        {
            try
            {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
			
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
			
            connection.Execute("dbo.DeleteFloorById @Id", parameters);
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
        
        public void Update(FloorDto floor)
        {
            try {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Execute("dbo.UpdateFloor @Id, @Name", floor);
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
