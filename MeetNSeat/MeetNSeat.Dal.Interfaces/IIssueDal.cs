using System.Collections.Generic;

namespace MeetNSeat.Dal.Interfaces
{
	public interface IIssueDal
	{
		List<IssueDto> GetAllIssues();
		void AddIssue(IssueDto issue);
		void Resolve(IssueDto issue);
	}
}