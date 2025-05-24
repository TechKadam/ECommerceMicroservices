
namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;

public record DeleteProductResult(bool ISuccess);

public class DeleteProductCommandHandler(ILogger<DeleteProductCommandHandler> logger, IDocumentSession session) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> HandleAsync(DeleteProductCommand request, CancellationToken cancellationToken = default)
    {
        var product = await session.LoadAsync<Product>(request.Id, cancellationToken);
        if (product is null) throw new ProductNotFoundException();
        session.Delete(product);
        await session.SaveChangesAsync(cancellationToken);
        return new DeleteProductResult(true);
    }
}
