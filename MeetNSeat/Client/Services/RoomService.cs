using System;
using System.Collections.Generic;
using System.Globalization;
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
			return await client.GetFromJsonAsync<List<RoomModel>>($"{Url.Address}/api/room");
		}

		public static async Task<IEnumerable<RoomModel>> GetAllAvailableRooms(int locationId, string roomType, int attendees, DateTime startTime, DateTime endTime, int roomId)
		{
			using var client = new HttpClient();
			var sqlStartTime = startTime.ToString("yyyy-MM-ddTHH:mm:ss.fff");
			var sqlEndTime = endTime.ToString("yyyy-MM-ddTHH:mm:ss");
			return await client.GetFromJsonAsync<List<RoomModel>>($"{Url.Address}/api/room/"+locationId+"/"+roomType+"/"+attendees+"/"+sqlStartTime+ "/"+ sqlEndTime+ "/" + roomId);
		}

		public static async Task<IEnumerable<RoomModel>> GetAllRoomTypes()
		{
			using var client = new HttpClient();
			return await client.GetFromJsonAsync<List<RoomModel>>($"{Url.Address}/api/user/types");
		}

	  public static async Task AddRoom(RoomModel room)
	  { 
		  using var client = new HttpClient(); 
		  await client.PostAsJsonAsync($"{Url.Address}/api/room", room);
	  }
	  
	  public static async Task DeleteRoom(int id)
	  {
		  using var client = new HttpClient();
		  await client.DeleteAsync($"{Url.Address}/api/room/{id}");
	  }
		
	  public static async Task UpdateRoom(RoomModel room)
	  {
		  using var client = new HttpClient();
		  await client.PutAsJsonAsync($"{Url.Address}/api/room", room);
	  }
	}
}