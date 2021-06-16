using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Logic
{
    public class UserScore
    {
        public string UserId { get; }
        #nullable enable
        public string? NickName { get; set; }
        public int? Count { get; set; }
        public int? AvaragePerc { get; set; }

        public UserScore(UserScoreDto dto)
        {
            UserId = dto.UserId;
            NickName = dto.NickName;
            Count = dto.Count;
            AvaragePerc = dto.AvaragePerc;
        }
    }
}
