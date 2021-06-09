using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Dal.Interfaces.Dtos;

namespace MeetNSeat.Dal
{
	public class ProblemDal : IProblemDal
	{
		public List<ProblemDto> GetAllProblems()
		{
			using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
			var output = connection.Query<ProblemDto>("dbo.GetAllProblems").ToList();
			return output;
		}

		public void AddProblem(ProblemDto problem)
		{
			using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
			connection.Execute("dbo.InsertProblem @RoomId, @UserId, @Email, @Description, @Picture, @ReportedOn, @IsResolved, @ResolvedAt", problem);
		}

		public void DeleteProblemById(int id)
		{
			using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());

			var parameters = new DynamicParameters();
			parameters.Add("@Id", id);

			connection.Execute("dbo.DeleteProblemById @Id", parameters);
		}

		public void UpdateProblem(ProblemDto problem)
		{
			using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
			connection.Execute("dbo.UpdateProblem @Id, @RoomId, @UserId, @Email, @Description, @Picture, @IsResolved, @ResolvedAt", problem);
		}
	}
}