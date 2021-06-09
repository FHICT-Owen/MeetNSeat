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

        public List<FloorDto> GetAllFloors()
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            var output = connection.Query<FloorDto>("dbo.GetAllFloors").ToList();
            return output;
        }

        public void AddFloor(FloorDto floorDto)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Execute("dbo.InsertFloor @Name, @LocationId", floorDto);
        }

        public void DeleteFloorById(int id)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
			
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
			
            connection.Execute("dbo.DeleteFloorById @Id", parameters);
        }
        
        public void Update(FloorDto floor)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Execute("dbo.UpdateFloor @Id, @Name", floor);
        }
    }
}
