using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using MeetNSeat.Dal.Interfaces;

namespace MeetNSeat.Dal
{
	public class IssueDal : IIssueDal
	{
		public List<IssueDto> GetAllIssues()
		{
			using IDbConnection connection = new SqlConnection(Connection.GetConnectionString("DefaultConnection"));
			var output = connection.Query<IssueDto>("").ToList();
			return output;
		}

		public void AddIssue(IssueDto issueDto)
		{
			using IDbConnection connection = new SqlConnection(Connection.GetConnectionString("DefaultConnection"));
			connection.Execute("dbo.InsertIssue @RoomId, @UserId, @Description, @CreatedOn, @IsResolved", issueDto);
		}

		public void Resolve()
		{
			throw new System.NotImplementedException();
		}
	}
}