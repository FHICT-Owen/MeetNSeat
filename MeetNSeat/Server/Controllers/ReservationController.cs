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
    public class ReservationController
    {
        private IManageReservation _manageReservation;

        public ReservationController(IManageReservation manageReservation)
        {
            _manageReservation = manageReservation;
        }

        [HttpPost("api")]
        public void CreateReservation()
        {
            _manageReservation.AddReservation(1, 1, 1, DateTime.Now, DateTime.Now);
        }

        //manageReservation = ReservationFactory.AddReservation();
        //manageReservation.AddReservation(1, 1, 1, DateTime.Now, DateTime.Now);
    }
}
