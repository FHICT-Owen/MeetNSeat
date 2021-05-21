using System.Collections.Generic;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Dal.Interfaces
{
	public interface IIssueDal
	{
		List<IssueDto> GetAllIssues();
		void AddIssue(IssueDto issue);
		void Update(IssueDto issue);
	}
}