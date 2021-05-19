using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MeetNSeat.Client.Models;

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
            var response = await client.PostAsJsonAsync("https://localhost:5001/api/user", reservation);
        }

        public static async Task<string> DeleteReservation(int id)
        {
            using var client = new HttpClient();
            var msg= await client.DeleteAsync("https://localhost:5001/api/user/" + id);
            if (msg.IsSuccessStatusCode)
            {
                return "Your reservation has been canceled";
            }
            else
            {
                return "Something went wrong :( Please try again later";
            }
        }
    }
}
