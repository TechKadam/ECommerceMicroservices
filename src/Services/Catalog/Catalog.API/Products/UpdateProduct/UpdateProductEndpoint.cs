namespace Catalog.API.Products.UpdateProduct;
public record UpdateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);

public record UpdateProductResponse(bool IsSuccess);
public class UpdateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/products/{id}", async ([FromRoute] Guid id, [FromBody] UpdateProductRequest request, ISender sender) =>
        {
            var updateProductCommand = request.Adapt<UpdateProductCommand>() with { Id = id };
            var result = await sender.SendAsync(updateProductCommand);
            var response = result.Adapt<UpdateProductResponse>();
            return Results.Ok(response);
        })
        .WithName("UpdateProduct")
        .Produces<UpdateProductResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Update existing product")
        .WithDescription("Update existing product");

    }
}
