using System;

namespace MeetNSeat.Logic
{
    public class Issue
    {
			public int IssueID { get; private set; }
			public int UserID { get; private set; }
			public int RoomID { get; private set; }
			public string IssueDescription { get; private set; }
			public bool IsResolved { get; private set; } = false;

			public Issue(int issueID, int userID, int roomID, string issueDescription)
			{
				IssueID = issueID;
				UserID = userID;
				RoomID = roomID;
				IssueDescription = issueDescription;
			}

			public void Resolve()
			{
				IsResolved = true;
			}
    }
}
