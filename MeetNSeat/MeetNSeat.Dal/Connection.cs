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
            string connection = ConfigurationLoader.GetConfiguration("../MeetNSeat.Server/appsettings")["ConnectionStrings:DefaultConnection"];
            return connection;
        }
    }
}