using MeetNSeat.Client.Models;
using System.Threading.Tasks;

namespace MeetNSeat.Client.Services
{
    public interface IApiClientService
    {
        Task<IpAddress> GetUserIPAsync();
    }
}
