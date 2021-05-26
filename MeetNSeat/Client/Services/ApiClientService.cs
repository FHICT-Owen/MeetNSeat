using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MeetNSeat.Client.Models;

namespace MeetNSeat.Client.Services
{
    public class ApiClientService : IApiClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ApiClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IpAddress> GetUserIpAsync()
        {
            var client = _httpClientFactory.CreateClient("IP");
            return await client.GetFromJsonAsync<IpAddress>("/");
        }
    }
}
