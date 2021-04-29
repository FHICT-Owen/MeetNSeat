using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MeetNSeat.Server.Controllers
{
	[ApiController]
	public class IssueController : ControllerBase
	{
		private readonly ILogger<IssueController> _logger;

		public IssueController(ILogger<IssueController> logger)
		{
			_logger = logger;
		}
		
		[HttpGet]
		public void Get()
		{
			
		}
	}
}