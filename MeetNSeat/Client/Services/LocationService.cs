using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MeetNSeat.Client.Models;

namespace MeetNSeat.Client.Services
{
	public static class LocationService
	{
        public static async Task<IEnumerable<LocationModel>> GetAllLocations()
        {
            using var client = new HttpClient();
            return await client.GetFromJsonAsync<List<LocationModel>>("https://localhost:5001/api/locations");
        }
        
        public static async Task AddLocation(LocationModel location)
        {
	        using var client = new HttpClient();
	        await client.PostAsJsonAsync("https://localhost:5001/api/locations", location);
        }
        
        public static async Task UpdateLocation(LocationModel location)
        {
	        using var client = new HttpClient();
	        await client.PutAsJsonAsync("https://localhost:5001/api/locations", location);
        }
	}
}