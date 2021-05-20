using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MeetNSeat.Client.Models;

namespace MeetNSeat.Client.Services
{
    public static class UserService
    {
        public static async Task<IEnumerable<ReservationModel>> GetAllReservations()
        {
            using var client = new HttpClient();
            return await client.GetFromJsonAsync<List<ReservationModel>>("https://localhost:5001/api/user");
        }

        public static async Task<bool> ConfirmReservation(int id, IpAddress address)
        {
            var client = new HttpClient();
            var response = await client.PostAsJsonAsync<ConfirmationModel>("https://localhost:5001/api/user/confirm", new ConfirmationModel(id, address.Ip));
            return response.IsSuccessStatusCode;
        }

        public static async Task<IEnumerable<RoomModel>> GetAllRoomTypes()
        {
            using var client = new HttpClient();
            return await client.GetFromJsonAsync<List<RoomModel>>("https://localhost:5001/api/user/types");
        }
        
        public static async Task CreateReservation(ReservationModel reservation)
        {
            using var client = new HttpClient();
            var response = await client.PostAsJsonAsync("https://localhost:5001/api/user", reservation);
        }
    }
}
