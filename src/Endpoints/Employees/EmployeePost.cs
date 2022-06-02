using iWantApp_Proj1.Domain.Products;
using iWantApp_Proj1.Infra.Data;
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
            return Results.BadRequest(result.Errors.First());

        return Results.Created($"/employee/{user.Id}", user.Id);
    }
}
