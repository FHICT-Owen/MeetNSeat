namespace MeetNSeat.Dal
{
    public static class Connection
    {
        public static string GetConnectionString(string name)
        {
            /*IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("./dbSettings.json")
                .Build();*/
            return "Data Source=cgi-wradbserver.database.windows.net;Initial Catalog=CGI-WRA_db;Persist Security Info=True;User ID=grotebaas;Password=Grote7856";
        }
    }
}