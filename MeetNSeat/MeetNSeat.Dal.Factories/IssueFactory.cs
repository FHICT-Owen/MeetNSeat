using MeetNSeat.Dal.Interfaces;

namespace MeetNSeat.Dal.Factories
{
	public static class IssueFactory
	{
		public static IProblemDal CreateIssueDal()
		{
			return new ProblemDal();
		}
	}
}