using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MeetNSeat.Client.Models;

namespace MeetNSeat.Client.Services
{
	public class IssueService
	{
		private readonly HttpClient _http;

		public IssueService(HttpClient http)
		{
			_http = http;
		}
		
		public async Task<IEnumerable<IssueModel>> GetAllIssues()
		{
			return await _http.GetFromJsonAsync<List<IssueModel>>("api/issues");
		}
		
		public async void AddIssue(IssueModel issue)
		{
			await _http.PostAsJsonAsync("api/issues", issue);
		}
	}
}