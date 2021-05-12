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
<<<<<<< HEAD
        public static async Task DeleteReservation(int id)
=======

        public static async Task CreateReservation(ReservationModel reservation)
        {
            using var client = new HttpClient();
            await client.PostAsJsonAsync("https://localhost:5001/api/reservation", reservation);
        }
        public static async Task DeleteReservering(int id)
>>>>>>> 6c626a5cc3ed86aa59e73de195f5fa62b81992de
        {
            using var client = new HttpClient();
            await client.DeleteAsync("https://localhost:5001/api/user/" + id);
        }
    }
}
