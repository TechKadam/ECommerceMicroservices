

namespace Catalog.API.Products.GetProductById;

public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
public record GetProductByIdResult(Product Product);
internal class GetProductByIdQueryHandler(ILogger<GetProductByIdQueryHandler> logger, IDocumentSession session) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> HandleAsync(GetProductByIdQuery request, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("GetProductByIdQueryHandler.Handle called with {@request}", request);
        var product = await session.LoadAsync<Product>(request.Id, cancellationToken);
        if (product is null)
        {
            throw new ProductNotFoundException();
        }
        return new GetProductByIdResult(product);

    }
}
