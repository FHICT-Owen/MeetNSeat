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
            return await client.GetFromJsonAsync<List<UserScoreModel>>($"{Url.Address}/api/feedback/");
        }

        public static async Task<IEnumerable<FeedbackModel>> GetAllFeedbackByUserId(string userId)
        {
            using var client = new HttpClient();
            return await client.GetFromJsonAsync<List<FeedbackModel>>($"{Url.Address}/api/feedback/{userId}");
        }

        public static async Task<bool> AddFeedback(FeedbackModel feedback)
        {
            using var client = new HttpClient();
            var response = await client.PostAsJsonAsync($"{Url.Address}/api/feedback", feedback);
            return response.IsSuccessStatusCode;
        }
    }
}