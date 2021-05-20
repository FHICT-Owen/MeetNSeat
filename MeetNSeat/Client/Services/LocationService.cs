using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using MeetNSeat.Client.Models;

namespace MeetNSeat.Client.Services
{
	public class LocationService
	{
        public static async Task<IEnumerable<LocationModel>> GetAllLocations()
        {
            using var client = new HttpClient();
            return await client.GetFromJsonAsync<List<LocationModel>>("https://localhost:5001/api/user");
        }
	}
}