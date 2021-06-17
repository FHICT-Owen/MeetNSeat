using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetNSeat.Client.Services
{
    public static class Url
    {
#if DEBUG
        public static string Address { get; } = "https://localhost:5001";
#else
        public static string Address { get; } = "https://meetnseatserver20210616191819.azurewebsites.net";
#endif
    }
}
