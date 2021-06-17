using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MeetNSeat.Client.Models;

namespace MeetNSeat.Client.Services
{
    public static class AuthService
    {

        public static async Task AddUser(UserModel userModel)
        {
            using var client = new HttpClient();
            await client.PostAsJsonAsync($"{Url.Address}/api/authentication/adduser", userModel);
        }

        public static async Task<int> GetUserRole(string userId)
        {
            using var client = new HttpClient();
            return await client.GetFromJsonAsync<int>($"{Url.Address}/api/authentication/user/{userId}");
        }
    }
}