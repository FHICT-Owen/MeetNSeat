﻿using Dapper;
using MeetNSeat.Dal.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using MeetNSeat.Dal.Interfaces.Dtos;
using System;

namespace MeetNSeat.Dal
{
    public class FeedbackDal : IFeedbackDal
    {
        public List<FeedbackDto> GetAllFeedback()
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            var output = connection.Query<FeedbackDto>("dbo.GetAllFeedback").ToList();
            return output;
        }
        public bool DeleteFeedback(int id)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());

            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@Id", id);

            var result = connection.Execute("dbo.DeleteFeedback @Id", parameter);
            if (result > 0) return true;
            return false;
        }
        public List<FeedbackDto> GetFeedbackDtoByUserId(string userId)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            
            var parameter = new DynamicParameters();
            parameter.Add("@UserId", userId);
            if (connection.Query<FeedbackDto>("dbo.GetFeedbackByUser @UserId", parameter).FirstOrDefault() != null)
            {
                var feedbackDto = connection.Query<FeedbackDto>("dbo.GetFeedbackByUser @UserId", parameter).ToList();
                return feedbackDto;
            }

            return null;
        }
        public bool InsertFeedback(FeedbackDto feedbackDto)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@Description", feedbackDto.Description);
            parameter.Add("@FeedbackState", feedbackDto.FeedbackState);
            parameter.Add("@UserId", feedbackDto.UserId);
            //TODO: 
            var result  = connection.Execute("dbo.InsertFeedback @Description, @FeedbackState, @UserId", parameter);
            if (result > 0) return true;
            return false;

        }
        public bool UpdateFeedback(FeedbackDto feedbackDto)
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@Id", feedbackDto.Id);
            parameter.Add("@Description", feedbackDto.Description);
            parameter.Add("@FeedbackState", feedbackDto.FeedbackState);

            var result = connection.Execute("dbo.UpdateFeedback @Id, @Description, @FeedbackState", feedbackDto);
            if (result > 0) return true;
            return false;
        }

        public List<UserScoreDto> GetAllUsersWithFeedback()
        {
            using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
            var output = connection.Query<UserScoreDto>("dbo.GetAllUsersWithFeedback").ToList();
            return output;
        }
    }
}
