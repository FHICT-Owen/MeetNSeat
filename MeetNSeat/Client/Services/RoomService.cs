using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MeetNSeat.Client.Models;

namespace MeetNSeat.Client.Services
{
	public static class RoomService
	{
		public static async Task<IEnumerable<RoomModel>> GetAllRooms()
		{
			using var client = new HttpClient();
			return await client.GetFromJsonAsync<List<RoomModel>>("https://localhost:5001/api/user");
		}

        public static async Task AddRoom(RoomModel room)
        {
            using var client = new HttpClient();
            await client.PostAsJsonAsync("https://localhost:5001/api/room", room);
        }
	}
}