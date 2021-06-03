using System;
using System.Collections.Generic;

namespace MeetNSeat.Logic.Interfaces
{
	public interface IManageIssue
	{
		IReadOnlyCollection<Issue> GetAllIssues();
		void AddIssue(int roomId, string userId, string email, string description, byte[] picture);
		void DeleteIssue(int id);
		void UpdateIssue(int id, int roomId, string userId, string email, string description, byte[] picture, bool isResolved, DateTime? resolvedAt);
	}
}