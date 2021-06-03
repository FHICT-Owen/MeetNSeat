using System;
using System.Collections.Generic;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Logic.Interfaces;

namespace MeetNSeat.Logic
{
  public class IssueCollection : IManageIssue
  {
    private readonly List<Issue> _issues = new();
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
    
    public void AddIssue(int roomId, string userId, string email, string description, byte[] picture)
    {
      var issue = new Issue(roomId, userId, email, description, picture);
      _issues.Add(issue);
      _dal.AddIssue(issue.ConvertToDto());
    }

    public void DeleteIssue(int id)
    {
      _issues.Remove(_issues.Find(issue => issue.Id == id));
      _dal.DeleteIssueById(id);
    }
    
    public void UpdateIssue(int id, int roomId, string userId, string email, string description, byte[] picture, bool isResolved, DateTime? resolvedAt)
    {
      _issues.Find(issue => issue.Id == id)?
        .Update(roomId, userId, email, description, picture, isResolved, resolvedAt);
    }
  }
}
