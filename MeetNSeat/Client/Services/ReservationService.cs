using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MeetNSeat.Client.Models;
using MeetNSeat.Client.Pages;

namespace MeetNSeat.Client.Services
{
    public static class ReservationService
    {
        public static async Task<bool> DeleteReservation(int id)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync("https://localhost:5001/api/user/" + id);
            return response.IsSuccessStatusCode;
        }
        
        public static async Task<IEnumerable<PeriodModel>> GetAllReservationsDateTimes(int locationId, string roomType, int attendees, DateTime startTime, DateTime endTime)
        {
            using var client = new HttpClient();
            return await client.GetFromJsonAsync<List<PeriodModel>>($"https://localhost:5001/api/user/{locationId}/{roomType}/{attendees}/{startTime}/{endTime}");
        }
    }
}
