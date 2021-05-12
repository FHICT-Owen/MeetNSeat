namespace MeetNSeat.Dal.Interfaces
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Auth0Id { get; set; }

        public UserDto(int userId, string name, string email, string auth0Id)
        {
            Id = userId;
            Email = email;
            Auth0Id = auth0Id;
        }
    }
}
