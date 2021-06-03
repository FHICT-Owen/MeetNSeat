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
			try
			{
				using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
				var output = connection.Query<ProblemDto>("dbo.GetAllProblems").ToList();
				return output;
			}
			catch (SqlException ex)
			{
				throw new DalExceptions("Database cannot connect, try again!");
			}
			catch (Exception ex)
			{
				throw new DalExceptions("something went wrong");
			}
		}

		public void AddProblem(ProblemDto problem)
		{
			// try
			// {
				using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
				connection.Execute("dbo.InsertProblem @RoomId, @UserId, @Email, @Description, @Picture, @ReportedOn, @IsResolved, @ResolvedAt", problem);
			// }
			// catch (SqlException ex)
			// {
			// 	throw new DalExceptions("Database cannot connect, try again!");
			// }
			// catch (Exception ex)
			// {
			// 	throw new DalExceptions("something went wrong");
			// }
		}

		public void DeleteProblemById(int id)
		{
            try
			{
				using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
			
				var parameters = new DynamicParameters();
				parameters.Add("@Id", id);
				
				connection.Execute("dbo.DeleteProblemById @Id", parameters);
			}
			catch (SqlException ex)
			{
				throw new DalExceptions("Database cannot connect, try again!");
			}
			catch (Exception ex)
			{
				throw new DalExceptions("something went wrong");
			}
		}
		
		public void UpdateProblem(ProblemDto problem)
		{
            try
			{
				using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
				connection.Execute("dbo.UpdateProblem @Id, @RoomId, @UserId, @Description, @IsResolved", problem);
			}
			catch (SqlException ex)
			{
				throw new DalExceptions("Database cannot connect, try again!");
			}
			catch (Exception ex)
			{
				throw new DalExceptions("something went wrong");
			}
		}
	}
}