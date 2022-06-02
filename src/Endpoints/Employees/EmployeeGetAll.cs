
using Dapper;
using iWantApp_Proj1.Infra.Data;
using Microsoft.Data.SqlClient;

namespace iWantApp_Proj1.Endpoints.Employees;

public class EmployeeGetAll
{
    public static string Template => "/employee";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(int? page, int? rows, QueryAllUsersWithClaimName query)
    {
        

        return Results.Ok(query.Execute(page.Value,rows.Value));
    }
}
