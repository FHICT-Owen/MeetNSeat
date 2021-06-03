using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetNSeat.Dal
{
    public class DalExceptions : Exception
    {
        public DalExceptions(string message) : base(message)
        {

        }
    }
}
