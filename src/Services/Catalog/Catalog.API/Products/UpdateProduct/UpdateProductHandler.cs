namespace Catalog.API.Products.UpdateProduct;

public record UpdateProductCommand(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<UpdateProductResult>;

public record UpdateProductResult(bool IsSuccess);


internal class UpdateProductCommandHandler(ILogger<UpdateProductCommandHandler> logger, IDocumentSession session) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> HandleAsync(UpdateProductCommand request, CancellationToken cancellationToken = default)
    {
        var product = await session.LoadAsync<Product>(request.Id, cancellationToken);

        if (product is null)
        {
            // Product not found
            throw new ProductNotFoundException();
        }

        // Map changes from request to the product entity
        request.Adapt(product);

        session.Update(product);
        await session.SaveChangesAsync(cancellationToken);

        return new UpdateProductResult(true);
    }
}
