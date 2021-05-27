
namespace MeetNSeat.Client.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Nickname { get; set; }
        public int Role { get; set; }

        public UserModel()
        {
            
        }

        public UserModel(string id, string nickname, int role)
        {
            Id = id;
            Nickname = nickname;
            Role = role;
        }
    }
}