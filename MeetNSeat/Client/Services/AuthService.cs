using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MeetNSeat.Client.Models;

namespace MeetNSeat.Client.Services
{
    public class AuthService
    {
        public static async Task AddUser(UserModel userModel)
        {
            using var client = new HttpClient();
            await client.PostAsJsonAsync("https://localhost:5001/api/auth", userModel);
        }
    }
}