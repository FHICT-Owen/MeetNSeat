using System.Collections.Generic;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Logic.Interfaces;

namespace MeetNSeat.Logic
{
  public class IssueCollection : IIssueCollection
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
    
    public void AddIssue(Issue issue)
    {
      _issues.Add(issue);
      _dal.AddIssue(issue.ConvertToDto());
    }
  }
}
