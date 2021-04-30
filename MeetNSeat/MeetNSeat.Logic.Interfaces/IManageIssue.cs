using System.Collections.Generic;

namespace MeetNSeat.Logic.Interfaces
{
	public interface IManageIssue
	{
		public void AddIssue(int userId, int roomId, string description);
	}
}