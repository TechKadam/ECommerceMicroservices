namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductResponse(bool ISuccess);
public class DeleteProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{id:guid}", async (Guid id, ISender sender) =>
        {
            var result = await sender.SendAsync(new DeleteProductCommand(id));
            var response = result.Adapt<DeleteProductResponse>();
            return Results.Ok(response);
        })
        .WithName("DeleteProduct")
        .Produces<DeleteProductResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete the product")
        .WithDescription("Delete the Product");
    }
}
