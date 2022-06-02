using Dapper;
using iWantApp_Proj1.Endpoints.Employees;
using Microsoft.Data.SqlClient;

namespace iWantApp_Proj1.Infra.Data;

public class QueryAllUsersWithClaimName
{
    private readonly IConfiguration configuration;

    public QueryAllUsersWithClaimName(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public IEnumerable<EmployeeResponse> Execute(int page, int rows)
    {
        var db = new SqlConnection(configuration["ConnectionString:IWantDb"]);

        var query = @"SELECT Email, ClaimValue as Name
                FROM [IWantDb].[dbo].[AspNetUsers] U
                INNER JOIN [IWantDb].[dbo].[AspNetUserClaims] C 
                ON U.id = C.UserId And claimtype = 'Name'
                ORDER BY Name
                OFFSET (@page - 1) * @rows ROWS FETCH NEXT @rows ROWS ONLY";

        return db.Query<EmployeeResponse>(
            query,
            new { page, rows }
        );
    }
}
