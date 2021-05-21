using System.Collections.Generic;

namespace MeetNSeat.Logic.Interfaces
{
	public interface IManageIssue
	{
		IReadOnlyCollection<Issue> GetAllIssues();
		void AddIssue(string description, int roomId, string userId);
		void UpdateIssue(int id, string description, int roomId, string userId, bool isResolved);
	}
}