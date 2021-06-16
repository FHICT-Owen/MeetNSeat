using System.Net.Http;
using System.Threading.Tasks;

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
    }
}
