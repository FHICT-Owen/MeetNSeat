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
            return await client.GetFromJsonAsync<List<ReservationModel>>($"{Url.Address}/api/user/" + userId);
        }

        public static async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            using var client = new HttpClient();
            return await client.GetFromJsonAsync<List<UserModel>>($"{Url.Address}/api/authentication/");
        }

        public static async Task<bool> ConfirmReservation(string address, ReservationModel reservation)
        {
            var client = new HttpClient();
            var response = await client.PutAsJsonAsync($"{Url.Address}/api/user/confirm/{address}",reservation);
            return response.IsSuccessStatusCode;
        }
       
        public static async Task<bool> CreateReservation(ReservationModel reservation)
        {
            using var client = new HttpClient();
            var response = await client.PostAsJsonAsync($"{Url.Address}/api/user", reservation);
            return response.IsSuccessStatusCode;
        }
        public static async Task<bool> EditReservation(ReservationModel reservation)
        {
            using var client = new HttpClient();
            var response = await client.PostAsJsonAsync($"{Url.Address}/api/user/edit", reservation);
            return response.IsSuccessStatusCode;
        }
    }
}
