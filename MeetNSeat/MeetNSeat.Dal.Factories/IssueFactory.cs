using MeetNSeat.Dal.Interfaces;

namespace MeetNSeat.Dal.Factories
{
	public static class IssueFactory
	{
		public static IIssueDal CreateIssueDal()
		{
			return new IssueDal();
		}
	}
}