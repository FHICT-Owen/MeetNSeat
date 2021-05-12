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
        public bool AddReservation(ReservationDto reservationDto)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString("DefaultConnection"));
            connection.Execute("dbo.CreateReservation @RoomId, @UserId, @Attendees, @CreatedOn, @StartTime, @EndTime, @IsConfirmed", reservationDto);
            //TODO: Iets anders voor bedenken
            return true;
        }

        public bool RemoveReservation(int id)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString("DefaultConnection"));
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@id", id);

            var result = connection.Execute("dbo.DeleteReservation @id", parameter);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void UpdateReservation(ReservationDto reservationDto)
        {
            // var entry = context.Reservations.SingleOrDefault(result => result.Id == reservationDto.Id);
            // if (entry == null) return;
            // context.Entry(entry).CurrentValues.SetValues(reservationDto);
            // context.SaveChanges();
        }

        public List<ManageReservationDto> GetReservationByUser(string id)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString("DefaultConnection"));

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserId", id);

            var output = connection.Query<ManageReservationDto>("dbo.GetAllUserReservations @UserId",parameters).ToList();
            return output;
            
        }


        public List<ManageReservationDto> GetAllReservations()
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString("DefaultConnection"));
            
            List<ManageReservationDto> output = connection.Query<ManageReservationDto>("dbo.GetAllReservations").ToList();
            return output;
        }
    }
}
