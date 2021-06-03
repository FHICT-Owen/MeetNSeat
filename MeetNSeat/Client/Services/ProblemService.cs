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
			return await client.GetFromJsonAsync<List<ProblemModel>>("https://localhost:5001/api/problem");
		}
		
		public static async Task AddProblem(ProblemModel problem)
		{
			using var client = new HttpClient();
			await client.PostAsJsonAsync("https://localhost:5001/api/problem", problem);
		}
		
		public static async Task DeleteProblem(int id)
		{
			using var client = new HttpClient();
			await client.DeleteAsync($"https://localhost:5001/api/problem/{id}");
		}
		
		public static async Task UpdateProblem(ProblemModel problem)
		{
			using var client = new HttpClient();
			await client.PutAsJsonAsync("https://localhost:5001/api/problem", problem);
		}
	}
}