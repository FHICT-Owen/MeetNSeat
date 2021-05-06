using System.Collections.Generic;
using System.Threading.Tasks;
using MeetNSeat.Client.Models;

namespace MeetNSeat.Client.Services
{
	public interface IIssueService
	{
		Task<IEnumerable<IssueModel>> GetAllIssues();
	}
}