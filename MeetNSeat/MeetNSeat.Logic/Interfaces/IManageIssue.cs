using System.Collections.Generic;

namespace MeetNSeat.Logic.Interfaces
{
	public interface IManageIssue
	{
		IReadOnlyCollection<Issue> GetAllIssues();
		void AddIssue(Issue issue);
	}
}