using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MeetNSeat.Client.Models;
using MeetNSeat.Server.Models;

namespace MeetNSeat.Client.Services
{
    public class UserService
    {
        private readonly HttpClient _http;

        public UserService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<UserModel>> GetAllReservations()
        {
            return await _http.GetFromJsonAsync<List<UserModel>>("api/user");
        }

        public static async Task CreateReservation(ReservationModel reservation)
        {
            using var client = new HttpClient();
            await client.PostAsJsonAsync("https://localhost:5001/api/reservation", reservation);
        }
        public static async Task DeleteReservering(int id)
        {
            using var client = new HttpClient();
            await client.PostAsJsonAsync("https://localhost:5001/api/user/delete", id);
        }
    }
}
