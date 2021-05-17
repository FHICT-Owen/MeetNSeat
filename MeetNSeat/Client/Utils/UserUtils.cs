using System.Threading.Tasks;
using Blazored.SessionStorage;

namespace MeetNSeat.Client.Utils
{
    public class UserUtils : IUserUtils
    {
        private readonly ISessionStorageService _storage;

        public UserUtils(ISessionStorageService storage)
        {
            _storage = storage;
        }

        public async Task<string> GetUserId()
        {
            return await _storage.GetItemAsync<string>("userId");
        }
    }
}