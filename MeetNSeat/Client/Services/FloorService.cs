using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MeetNSeat.Client.Models;

namespace MeetNSeat.Client.Services
{
    public static class FloorService
    {
        public static async Task<IEnumerable<FloorModel>> GetAllFloorsAndRoomsByLocationId()
        {
            using var client = new HttpClient();
            return await client.GetFromJsonAsync<List<FloorModel>>("https://localhost:5001/api/floor");
        }
        
        public static async Task PostId(int locationId)
        {
            using var client = new HttpClient();
            await client.PostAsJsonAsync("https://localhost:5001/api/floor", locationId);
        }

        public static async Task AddFloor(FloorModel floor)
        {
            using var client = new HttpClient();
            await client.PostAsJsonAsync("https://localhost:5001/api/floor", floor);
        }
    }
}
