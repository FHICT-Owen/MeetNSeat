using System.Configuration;

namespace MeetNSeat.Dal
{
    public static class Connection
    {
        public static string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}