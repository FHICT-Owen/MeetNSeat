using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MeetNSeat.Client.Models;

namespace MeetNSeat.Client.Services
{
    public static class ReservationService
    {
        public static async Task<string> DeleteReservation(int id)
        {
            using var client = new HttpClient();
            var msg = await client.DeleteAsync("https://localhost:5001/api/reservation/" + id);
            if (msg.IsSuccessStatusCode)
            {
                return "Your reservation has been canceled";
            }
            else
            {
                return "Something went wrong :( Please try again later";
            }
        }
    }
}
