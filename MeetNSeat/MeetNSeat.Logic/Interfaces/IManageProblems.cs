using System;
using System.Collections.Generic;

namespace MeetNSeat.Logic.Interfaces
{
	public interface IManageProblems
	{
		IReadOnlyCollection<Problem> GetAllProblems();
		void AddProblem(int roomId, string userId, string email, string description, byte[] picture);
		void DeleteProblem(int id);
		void UpdateProblem(int id, int roomId, string userId, string email, string description, byte[] picture, bool isResolved, DateTime? resolvedAt);
	}
}