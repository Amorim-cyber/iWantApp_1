using iWantApp_Proj1.Domain.Products;
using iWantApp_Proj1.Infra.Data;

namespace iWantApp_Proj1.Endpoints.Categories;

public class CategoryGetAll
{
    public static string Template => "/categories";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(ApplicationDbContext context)
    {
        var categories = context.Categories.ToList();
        var response = categories.Select(c => new CategoryResponse { Id = c.Id, Name = c.Name, Active = c.Active, });
        return Results.Ok(response);
    }
}
