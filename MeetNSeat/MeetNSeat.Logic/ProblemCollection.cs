using System;
using System.Collections.Generic;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Logic.Interfaces;

namespace MeetNSeat.Logic
{
  public class ProblemCollection : IManageProblems
  {
    private readonly List<Problem> _problems = new();
    private readonly IProblemDal _dal;

    public ProblemCollection()
    {
      _dal = ProblemFactory.CreateIssueDal();
    }
    
    public IReadOnlyCollection<Problem> GetAllProblems() 
    {
      _problems.Clear();

      _dal.GetAllProblems().ForEach(
        dto => _problems.Add(new Problem(dto)));
			
      return _problems.AsReadOnly();
    }
    
    public void AddProblem(int roomId, string userId, string email, string description, byte[] picture)
    {
      var issue = new Problem(roomId, userId, email, description, picture);
      _problems.Add(issue);
      _dal.AddProblem(issue.ConvertToDto());
    }

    public void DeleteProblem(int id)
    {
      _problems.Remove(_problems.Find(issue => issue.Id == id));
      _dal.DeleteProblemById(id);
    }
    
    public void UpdateProblem(int id, int roomId, string userId, string email, string description, byte[] picture, bool isResolved, DateTime? resolvedAt)
    {
      _problems.Find(issue => issue.Id == id)?
        .Update(roomId, userId, email, description, picture, isResolved, resolvedAt);
    }
  }
}
