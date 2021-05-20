using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetNSeat.Dal.Interfaces.Dtos
{
    public class FloorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }

        public FloorDto()
        {
            
        }
    }
}
