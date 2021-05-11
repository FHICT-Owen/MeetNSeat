﻿using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeetNSeat.Logic
{
    public class User : IManageReservation
    {
        public int Id { get; set; }

        private List<Reservation> reservations = new List<Reservation>();
        private IReservationDal dal;

        public User()
        {
            // Factory
            dal = ReservationFactory.CreateReservationDal();
        }

        public List<ReservationDto> GetAllReservations()
        {
            return dal.GetAllReservations();
            
        }

        public List<ReservationDto> GetReservationByUser(string userId)
        {
            return dal.GetReservationByUser(userId);
        }

        public bool AddReservation(int roomId, string type, int locationId, string userId, int attendees, DateTime startTime, DateTime endTime)
        {

            // Retrieve rooms by type and location
            Room room = new Room();
            var rooms = room.GetAvailableRooms(type, locationId);

            Reservation reservation = new Reservation();
            var reservations = reservation.GetAllReservations();

            //TODO: Check if any room is available on given date
            // Loop trough reservations with given room id
            // Check if there is no reservation in given start and end

            if (reservations.Where(r => r.RoomId == roomId).Any(r => startTime > r.StartTime || endTime < r.EndTime))
            {
                return false;
            }
            //TODO: Set reservation
            ReservationDto reservationDto = new ReservationDto(roomId, userId, attendees, startTime, endTime);
            return dal.AddReservation(reservationDto);
            // Room available
        }
    }
}
