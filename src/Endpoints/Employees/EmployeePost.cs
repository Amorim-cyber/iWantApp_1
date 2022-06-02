using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace iWantApp_Proj1.Endpoints.Employees;

public class EmployeePost
{
    public static string Template => "/employee";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(EmployeeRequest employeesRequest, UserManager<IdentityUser> userManager)
    {
        var user = new IdentityUser()
        {
            UserName = employeesRequest.Email,
            Email = employeesRequest.Email 

        };
        var result = userManager.CreateAsync(user, employeesRequest.Password).Result;

        if (!result.Succeeded)
            return Results.ValidationProblem(result.Errors.ConvertToProblemDetails());

        var userClaims = new List<Claim>
        {
            new Claim("EmployeeCode", employeesRequest.EmployeeCode),
            new Claim("Name", employeesRequest.Name)
        };

        var claimResult = userManager.AddClaimsAsync(user, userClaims).Result;

        if (!claimResult.Succeeded)
            return Results.BadRequest(claimResult.Errors.First());

        return Results.Created($"/employee/{user.Id}", user.Id);
    }
}
