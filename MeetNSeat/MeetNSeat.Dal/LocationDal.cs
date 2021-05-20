using Dapper;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Dal.Interfaces.Dtos;
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
    }
}