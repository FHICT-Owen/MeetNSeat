using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MeetNSeat.Client.Models;

namespace MeetNSeat.Client.Services
{
    public static class FeedbackService
    {
        public static async Task<IEnumerable<FeedbackModel>> GetAllFeedback(string userId)
        {
            using var client = new HttpClient();
            return await client.GetFromJsonAsync<List<FeedbackModel>>("https://localhost:5001/api/feedback/" + userId);
        }

        public static async Task<string> AddFeedback(FeedbackModel feedback)
        {
            using var client = new HttpClient();
            var response = await client.PostAsJsonAsync("https://localhost:5001/api/feedback", feedback);
            if (response.IsSuccessStatusCode) return "Feedback is Send!";
            return "Error! Something went wrong, please try again!";
        }
    }
}