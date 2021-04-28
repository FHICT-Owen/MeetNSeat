using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MeetNSeat.Client.Models;

namespace MeetNSeat.Client.Services
{
    public interface IApiClientService
    {
        Task<IpAddress> GetUserIPAsync();
    }
}
