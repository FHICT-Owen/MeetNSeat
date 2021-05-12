using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetNSeat.Logic;
using MeetNSeat.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace MeetNSeat.Server.Controllers
{
    [Route("api/reservation")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private IManageReservation _manageReservation;

        public ReservationController(IManageReservation manageReservation)
        {
            _manageReservation = manageReservation;
        }

        [HttpPost]
        public void CreateReservation()
        {

        }

        //manageReservation = ReservationFactory.AddReservation();
        //manageReservation.AddReservation(1, 1, 1, DateTime.Now, DateTime.Now);
    }
}
