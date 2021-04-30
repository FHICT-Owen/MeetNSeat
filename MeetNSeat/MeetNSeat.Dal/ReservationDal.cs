using System.Collections.Generic;
using System.Data;
using Dapper;
using MeetNSeat.Dal.Interfaces;
using System.Data.SqlClient;
using System.Linq;

namespace MeetNSeat.Dal
{
    public class ReservationDal : IReservationDal
    {
        public void AddReservation(ReservationDto reservationDto)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString("DefaultConnection"));
            connection.Execute("dbo.CreateReservation @RoomId, @UserId, @Attendees, @CreatedOn, @StartTime, @EndTime, @IsConfirmed", reservationDto);
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

        public List<ReservationDto> GetReservationByUser(int id)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString("DefaultConnection"));

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserId", id);

            var output = connection.Query<ReservationDto>("dbo.GetAllUserReservations @UserId",parameters).ToList();
            return output;
            
        }


        public List<ReservationDto> GetAllReservations()
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString("DefaultConnection"));
            
            var output = connection.Query<ReservationDto>("dbo.GetAllReservations").ToList();
            return output;

        }
    }
}
