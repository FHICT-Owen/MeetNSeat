using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MeetNSeat.Client.Models;

namespace MeetNSeat.Client.Services
{
    public class ApiClientService : IApiClientService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public ApiClientService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IpAddress> GetUserIPAsync()
        {
            var client = httpClientFactory.CreateClient("IP");
            return await client.GetFromJsonAsync<IpAddress>("/");
        }
    }
}
