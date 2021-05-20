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
            return await client.GetFromJsonAsync<List<LocationModel>>("https://localhost:5001/api/location");
        }
        
        public static async Task AddIssue(LocationModel location)
        {
	        using var client = new HttpClient();
	        await client.PostAsJsonAsync("https://localhost:5001/api/location", location);
        }
	}
}