namespace MeetNSeat.Dal.Interfaces.Dtos
{
    public class UserDto
    {
        public string UserId { get; set; }
        public string Nickname { get; set; }
        public int RoleId { get; set; }

        public UserDto() { }
        public UserDto(string userId, string nickname, int roleId)
        {
            UserId = userId;
            Nickname = nickname;
            RoleId = roleId;
        }
    }
}
