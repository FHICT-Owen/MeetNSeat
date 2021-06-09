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
    public class LocationDal : ILocationDal
    {
        
        public List<LocationDto> GetAllLocations()
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            var output = connection.Query<LocationDto>("dbo.GetAllLocations").ToList();
            return output;
        }

        public void AddLocation(LocationDto locationDto)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Execute("dbo.InsertLocation @Name, @City, @IpAddress ", locationDto);
        }
        
        public void DeleteLocationById(int id)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
			
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
			
            connection.Execute("dbo.DeleteLocationById @Id", parameters);
        }
        
        public void UpdateLocation(LocationDto location)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Execute("dbo.UpdateLocation @Id, @Name, @City, @IpAddress", location);
        }
    }
}