using System.Threading.Tasks;

namespace MeetNSeat.Client.Utils
{
    public interface IUserUtils
    {
        Task<string> GetUserId();
    }
}