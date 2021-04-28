using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using MeetNSeat.Dal.Interfaces;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MeetNSeat.Dal
{
    public class ReservationDal : IReservationDal
    {
        public List<ReservationDto> GetAllReservations()
        {
            // var reservationList = context.Reservations.ToList();
            // return reservationList;
            return null;
        }

        public void AddReservation(ReservationDto reservationDto)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString("DefaultConnection"));
            connection.Execute("dbo.CreateReservation @RoomId, @UserId, @Attendees, @CreatedOn, @StartTime, @EndTime, @IsConfirmed",
                reservationDto);
            
            //connection.Execute("", reservationDto);


        }

        public void RemoveReservation(ReservationDto reservationDto)
        {
            // var entry = context.Reservations.SingleOrDefault(result => result.Id == reservationDto.Id);
            // if (entry == null) return;
            // context.Reservations.Remove(entry);
            // context.SaveChanges();
        }

        public void UpdateReservation(ReservationDto reservationDto)
        {
            // var entry = context.Reservations.SingleOrDefault(result => result.Id == reservationDto.Id);
            // if (entry == null) return;
            // context.Entry(entry).CurrentValues.SetValues(reservationDto);
            // context.SaveChanges();
        } 
    }
}
