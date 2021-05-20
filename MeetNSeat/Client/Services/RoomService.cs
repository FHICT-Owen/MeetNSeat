using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using MeetNSeat.Client.Models;

namespace MeetNSeat.Client.Services
{
	public class RoomService
	{
		public static async Task<IEnumerable<RoomModel>> GetAllRoomTypes()
		{
			using var client = new HttpClient();
			return await client.GetFromJsonAsync<List<RoomModel>>("https://localhost:5001/api/user");
		}
    }
}