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
	public class IssueDal : IIssueDal
	{
		public List<IssueDto> GetAllIssues()
		{
			try
			{
			using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
			var output = connection.Query<IssueDto>("dbo.GetAllIssues").ToList();
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

		public void AddIssue(IssueDto issue)
		{
			try
			{
			using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
			connection.Execute("dbo.InsertIssue @RoomId, @UserId, @Email, @Description, @Picture, @ReportedOn, @IsResolved, @ResolvedAt", issue);
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

		public void DeleteIssueById(int id)
		{
            try
			{
			using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
			
			var parameters = new DynamicParameters();
			parameters.Add("@Id", id);
			
			connection.Execute("dbo.DeleteIssueById @Id", parameters);
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
		
		public void Update(IssueDto issue)
		{
            try
			{
			using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
			connection.Execute("dbo.UpdateIssue @Id, @RoomId, @UserId, @Description, @IsResolved", issue);
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