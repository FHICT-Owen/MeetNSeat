using System.Collections.Generic;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;

namespace MeetNSeat.Logic
{
  public class IssueCollection
  {
    private readonly List<Issue> _issues = new List<Issue>();
    private readonly IIssueDal _dal;

    public IssueCollection()
    {
      _dal = IssueFactory.CreateIssueDal();
    }
    
    public IReadOnlyCollection<Issue> GetAllIssues() 
    {
      _issues.Clear();

      _dal.GetAllIssues().ForEach(
        dto => _issues.Add(new Issue(dto)));
			
      return _issues.AsReadOnly();
    }
    
    public void AddIssue(int roomId, int userId, string description)
    {
      var issue = new Issue(roomId, userId, description);
      _issues.Add(issue);
      _dal.AddIssue(issue.ConvertToDto());
    }
  }
}
