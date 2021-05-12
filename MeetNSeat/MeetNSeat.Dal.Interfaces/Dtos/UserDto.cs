namespace MeetNSeat.Dal.Interfaces.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Auth0Id { get; set; }

        public UserDto(string userId)
        {
            Id = userId;
        }
    }
}
