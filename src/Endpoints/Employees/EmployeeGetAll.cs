using iWantApp_Proj1.Infra.Data;
using Microsoft.AspNetCore.Authorization;

namespace iWantApp_Proj1.Endpoints.Employees;

public class EmployeeGetAll
{
    public static string Template => "/employee";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    [Authorize(Policy = "EmployeeTESTE02Policy")]
    public static IResult Action(int? page, int? rows, QueryAllUsersWithClaimName query)
    {
        

        return Results.Ok(query.Execute(page.Value,rows.Value));
    }
}
