using System.Collections.Generic;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Dal.Interfaces
{
	public interface IProblemDal
	{
		List<ProblemDto> GetAllProblems();
		void AddProblem(ProblemDto problem);
		void DeleteProblemById(int id);
		void UpdateProblem(ProblemDto problem);
	}
}