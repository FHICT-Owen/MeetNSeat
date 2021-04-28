using System;
using System.Configuration;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace MeetNSeat.Dal
{
    public static class Connection
    {
        public static string GetConnectionString(string name)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("dbSettings.json")
                .Build();
            return configuration.GetConnectionString(name);
        }
    }
}