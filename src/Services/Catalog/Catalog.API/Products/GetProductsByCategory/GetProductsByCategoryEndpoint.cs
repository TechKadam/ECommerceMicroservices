using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Products.GetProductsByCategory
{
    public class GetProductsByCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{category}", async ([FromRoute] string category, ISender sender) =>
            {
                var result = await sender.SendAsync(new GetProductsByCategoryQuery(category));
                var response = result.Adapt<GetProductsByCategoryResponse>();
                return Results.Ok(response);
            })
            .WithName("GetProductsByCategory")
            .Produces<GetProductsByCategoryResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Gets products by category")
            .WithDescription("Get products by category");
        }
    }

    public record GetProductsByCategoryResponse(IEnumerable<Product> Products);

}
