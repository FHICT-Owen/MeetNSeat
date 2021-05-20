using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MeetNSeat.Client.Models;

namespace MeetNSeat.Client.Services
{
    public class UserService
    {
        public async Task<IEnumerable<ReservationModel>> GetAllReservations()
        {
            using var client = new HttpClient();
            return await client.GetFromJsonAsync<List<ReservationModel>>("https://localhost:5001/api/user");
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
