using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using MeetNSeat.Dal.Interfaces;
using System.Data.SqlClient;
using System.Linq;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Dal
{
    public class ReservationDal : IReservationDal
    {
        public bool AddReservation(CreateReservationDto createReservationDto)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            connection.Execute("dbo.CreateReservation @RoomId, @UserId, @Attendees, @StartTime, @EndTime", createReservationDto);
            return true;
        }
        public bool ConfirmReservation(int id, DateTime confirmedTime)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@id", id);
            parameter.Add("@confirmed", confirmedTime);

            var result = connection.Execute("dbo.ConfirmReservation @id, @confirmed", parameter);
            return result > 0;
        }

        public bool RemoveReservation(int id)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
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

        public bool UpdateReservation(ReservationDto reservationDto)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@room", reservationDto.RoomId);
            parameters.Add("@attendees", reservationDto.Attendees);
            parameters.Add("@start", reservationDto.StartTime);
            parameters.Add("@end", reservationDto.EndTime);
            parameters.Add("@reservation", reservationDto.Id);
            var results = connection.Execute("dbo.UpdateReservation @room, @attendees, @start, @end, @reservation", parameters);
            if (results > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<ManageReservationDto> GetReservationByUser(string id)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserId", id);

            var output = connection.Query<ManageReservationDto>("dbo.GetAllUserReservations @UserId",parameters).ToList();
            return output;
            
        }

        public List<ManageReservationDto> GetAllReservations()
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            
            List<ManageReservationDto> output = connection.Query<ManageReservationDto>("dbo.GetAllReservations").ToList();
            return output;
        }
    }
}
