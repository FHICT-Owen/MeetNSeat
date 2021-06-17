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
        return await client.GetFromJsonAsync<List<LocationModel>>($"{Url.Address}/api/location");
    }
    
    public static async Task AddLocation(LocationModel location)
    {
      using var client = new HttpClient();
      await client.PostAsJsonAsync($"{Url.Address}/api/location", location);
    }
    
    public static async Task DeleteLocation(int id)
    {
      using var client = new HttpClient();
      await client.DeleteAsync($"{Url.Address}/api/location/{id}");
    }
    
    public static async Task UpdateLocation(LocationModel location)
    {
      using var client = new HttpClient();
      await client.PutAsJsonAsync($"{Url.Address}/api/location", location);
    }
	}
}