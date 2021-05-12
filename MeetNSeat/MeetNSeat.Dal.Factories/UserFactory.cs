using MeetNSeat.Dal.Interfaces;

namespace MeetNSeat.Dal.Factories
{
    public static class UserFactory
    {
        public static IUserDal CreateUserDal()
        {
            return new UserDal();
        }
    }
}