using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Products.GetProductById;

public class GetProductByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async ([FromRoute] Guid id, ISender sender) =>
        {
            var result = await sender.SendAsync(new GetProductByIdQuery(id));
            var response = result.Adapt<GetProductByIdResponse>();
            return Results.Ok(response);
        })
        .WithName("GetProductById")
        .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Gets product by id")
        .WithDescription("Get product by id");
    }
}

public record GetProductByIdResponse(Product Product);
