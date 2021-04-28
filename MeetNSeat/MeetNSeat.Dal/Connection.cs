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
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("../MeetNSeat.Server/appsettings.Development.json")
                .Build();
            return configuration.GetConnectionString(name);
        }
    }
}