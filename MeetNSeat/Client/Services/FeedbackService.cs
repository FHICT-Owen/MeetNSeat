using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MeetNSeat.Client.Models;

namespace MeetNSeat.Client.Services
{
    public class FeedbackService
    {
        private readonly HttpClient _http;

        public FeedbackService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<FeedbackModel>> GetAllFeedback()
        {
            return await _http.GetFromJsonAsync<List<FeedbackModel>>("api/feedback");
        }
    }
}
