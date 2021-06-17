using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MeetNSeat.Client.Models;

namespace MeetNSeat.Client.Services
{
	public static class ProblemService
	{
		public static async Task<IEnumerable<ProblemModel>> GetAllProblems()
		{
			using var client = new HttpClient();
			return await client.GetFromJsonAsync<List<ProblemModel>>($"{Url.Address}/api/problem");
		}
		
		public static async Task<bool> AddProblem(ProblemModel problem)
		{
			using var client = new HttpClient();
			var response = await client.PostAsJsonAsync($"{Url.Address}/api/problem", problem);
            return response.IsSuccessStatusCode;
        }
		
		public static async Task DeleteProblem(int id)
		{
			using var client = new HttpClient();
			await client.DeleteAsync($"{Url.Address}/api/problem/{id}");
		}
		
		public static async Task UpdateProblem(ProblemModel problem)
		{
			using var client = new HttpClient();
			await client.PutAsJsonAsync($"{Url.Address}/api/problem", problem);
		}
	}
}