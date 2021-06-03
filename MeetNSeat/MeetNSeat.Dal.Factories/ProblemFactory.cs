using MeetNSeat.Dal.Interfaces;

namespace MeetNSeat.Dal.Factories
{
	public static class ProblemFactory
	{
		public static IProblemDal CreateIssueDal()
		{
			return new ProblemDal();
		}
	}
}