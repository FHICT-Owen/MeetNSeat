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
			using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
			var output = connection.Query<IssueDto>("dbo.GetAllIssues").ToList();
			return output;
		}

		public void AddIssue(IssueDto issue)
		{
			using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
			connection.Execute("dbo.InsertIssue @RoomId, @UserId, @Description, @CreatedOn, @IsResolved", issue);
		}

		public void DeleteIssueById(int id)
		{
			using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
			
			var parameters = new DynamicParameters();
			parameters.Add("@Id", id);
			
			connection.Execute("dbo.DeleteIssueById @Id", parameters);
		}
		
		public void Update(IssueDto issue)
		{
			using IDbConnection connection = new SqlConnection(Connection.GetConnectionString());
			connection.Execute("dbo.UpdateIssue @Id, @RoomId, @UserId, @Description, @IsResolved", issue);
		}
	}
}