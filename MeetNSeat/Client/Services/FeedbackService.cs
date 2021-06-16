using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MeetNSeat.Client.Models;

namespace MeetNSeat.Client.Services
{
    public static class FeedbackService
    {
        public static async Task<IEnumerable<UserScoreModel>> GetAllUsersWithFeedback()
        {
            using var client = new HttpClient();
            return await client.GetFromJsonAsync<List<UserScoreModel>>("https://localhost:5001/api/feedback/");
        }

        public static async Task<IEnumerable<FeedbackModel>> GetAllFeedbackByUserId(string userId)
        {
            using var client = new HttpClient();
            return await client.GetFromJsonAsync<List<FeedbackModel>>("https://localhost:5001/api/feedback/" + userId);
        }

        public static async Task<bool> AddFeedback(FeedbackModel feedback)
        {
            using var client = new HttpClient();
            var response = await client.PostAsJsonAsync("https://localhost:5001/api/feedback", feedback);
            return response.IsSuccessStatusCode;
        }
    }
}