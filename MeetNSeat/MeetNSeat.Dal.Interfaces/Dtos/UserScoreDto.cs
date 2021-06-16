using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetNSeat.Dal.Interfaces.Dtos
{
    public class UserScoreDto
    {
        public string UserId { get; }
        #nullable enable
        public string? NickName { get; set; }
        public int? Count { get; set; }
        public int? AvaragePerc { get; set; }

        public UserScoreDto()
        {
            
        }
        public UserScoreDto(string userId, string? nickName, int? count, int? avaragePerc)
        {
            UserId = userId;
            NickName = nickName;
            Count = count;
            AvaragePerc = avaragePerc;
        }
    }
}
