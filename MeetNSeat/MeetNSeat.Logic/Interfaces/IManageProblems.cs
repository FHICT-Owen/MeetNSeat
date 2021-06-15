using System;
using System.Collections.Generic;

namespace MeetNSeat.Logic.Interfaces
{
	public interface IManageProblems
	{
		IReadOnlyCollection<Problem> GetAllProblems();
		void AddProblem(string locationName, string roomName, string userId, string nickname, string email, string title, string description, byte[] picture);
		void DeleteProblem(int id);
		void UpdateProblem(int id, string locationName, string roomName, string userId, string nickname, string email, string title, string description, byte[] picture, bool isResolved, DateTime? resolvedAt);
	}
}