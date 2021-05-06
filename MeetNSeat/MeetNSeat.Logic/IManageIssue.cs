using System.Collections.Generic;

namespace MeetNSeat.Logic
{
	public interface IManageIssue
	{
		IReadOnlyCollection<Issue> GetAllIssues();
		void AddIssue(Issue issue);
	}
}