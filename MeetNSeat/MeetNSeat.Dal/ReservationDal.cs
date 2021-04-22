using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Dal.DbContext;

namespace MeetNSeat.Dal
{
    public class ReservationDal : IReservationDal
    {
        private readonly DbContext.DbContext context; 
        public List<ReservationDto> GetAllReservations()
        {
            var reservationList = context.Reservations.ToList();
            return reservationList;
        }

        public void AddReservation(ReservationDto reservationDto)
        {
            context.Reservations.Add(reservationDto);
            context.SaveChanges();
        }

        public void RemoveReservation(ReservationDto reservationDto)
        {
            var entry = context.Reservations.SingleOrDefault(result => result.Id == reservationDto.Id);
            if (entry == null) return;
            context.Reservations.Remove(entry);
            context.SaveChanges();
        }

        public void UpdateReservation(ReservationDto reservationDto)
        {
            var entry = context.Reservations.SingleOrDefault(result => result.Id == reservationDto.Id);
            if (entry == null) return;
            context.Entry(entry).CurrentValues.SetValues(reservationDto);
            context.SaveChanges();
        } 
    }
}
