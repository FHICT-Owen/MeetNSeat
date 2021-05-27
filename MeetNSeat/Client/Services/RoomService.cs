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
			return await client.GetFromJsonAsync<List<RoomModel>>("https://localhost:5001/api/room");
		}
		
		public static async Task<IEnumerable<RoomModel>> GetAllRoomTypes()
		{
			using var client = new HttpClient();
			return await client.GetFromJsonAsync<List<RoomModel>>("https://localhost:5001/api/user/types");
		}

	  public static async Task AddRoom(RoomModel room)
	  { 
		  using var client = new HttpClient(); 
		  await client.PostAsJsonAsync("https://localhost:5001/api/room", room);
	  }
	  
	  public static async Task DeleteRoom(int id)
	  {
		  using var client = new HttpClient();
		  await client.DeleteAsync($"https://localhost:5001/api/room/{id}");
	  }
		
	  public static async Task UpdateRoom(RoomModel room)
	  {
		  using var client = new HttpClient();
		  await client.PutAsJsonAsync("https://localhost:5001/api/room", room);
	  }
	}
}