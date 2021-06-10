using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MeetNSeat.Client.Models;

namespace MeetNSeat.Client.Services
{
    public static class UserService
    {
        public static async Task<IEnumerable<ReservationModel>> GetUserReservations(string userId)
        {
            using var client = new HttpClient();
            return await client.GetFromJsonAsync<List<ReservationModel>>("https://localhost:5001/api/user/" + userId);
        }

        public static async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            using var client = new HttpClient();
            return await client.GetFromJsonAsync<List<UserModel>>("https://localhost:5001/api/user/");
        }

        public static async Task<bool> ConfirmReservation(int id, string address)
        {
            var client = new HttpClient();
            var response = await client.PostAsJsonAsync("https://localhost:5001/api/user/confirm"+id,address);
            return response.IsSuccessStatusCode;
        }
       
        public static async Task CreateReservation(ReservationModel reservation)
        {
            using var client = new HttpClient();
            var response = await client.PostAsJsonAsync("https://localhost:5001/api/user", reservation);
        }
        public static async Task<string> EditReservation(ReservationModel reservation)
        {
            using var client = new HttpClient();
            var msg = await client.PostAsJsonAsync("https://localhost:5001/api/user/edit", reservation);
            if (msg.IsSuccessStatusCode) return "Your reservation has been edited";
            return "Something went wrong :( Please try again later";
        }
    }
}
