using Microsoft.AspNetCore.Mvc;

namespace MeetNSeat.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase { }
}