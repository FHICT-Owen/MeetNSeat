using Microsoft.Extensions.Configuration;

namespace MeetNSeat.Dal
{
    public static class Connection
    {
        public static string GetConnectionString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("dbSettings.json")
                .Build();
            return configuration.GetConnectionString("DefaultConnection");
        }
    }
}