using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MeetNSeat.Client.Models;

namespace MeetNSeat.Client.Services
{
	public static class IssueService
	{
		public static async Task<IEnumerable<IssueModel>> GetAllIssues()
		{
			using var client = new HttpClient();
			return await client.GetFromJsonAsync<List<IssueModel>>("https://localhost:5001/api/issues");
		}
		
		public static async Task AddIssue(IssueModel issue)
		{
			using var client = new HttpClient();
			await client.PostAsJsonAsync("https://localhost:5001/api/issues", issue);
		}
	}
}