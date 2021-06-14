using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;

namespace MeetNSeat.Dal
{
    public static class Connection
    {
        public static string GetConnectionString()
        {
            try
            {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("dbSettings.json")
                .Build();
            return configuration.GetConnectionString("DefaultConnection");
            }
            catch (SqlException)
            {
                throw new DalExceptions("Database cannot connect, try again!");
            }
            catch (Exception)
            {
                throw new DalExceptions("something went wrong");
            }
        }
    }
}