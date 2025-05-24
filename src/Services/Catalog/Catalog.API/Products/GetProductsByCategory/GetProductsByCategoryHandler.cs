
namespace Catalog.API.Products.GetProductsByCategory;

public record GetProductsByCategoryQuery(string Category) : IQuery<GetProductsByCategoryResult>;
public record GetProductsByCategoryResult(IEnumerable<Product> Products);
internal class GetProductsByCategoryQueryHandler(IDocumentSession session, ILogger<GetProductsByCategoryQueryHandler> logger) : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryResult>
{
    public async Task<GetProductsByCategoryResult> HandleAsync(GetProductsByCategoryQuery request, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("GetProductByCategoryQueryHandler.Handle called with {@request}", request);
        var products = await session
        .Query<Product>()
        .Where(p => p.Category.Contains(request.Category))
        .ToListAsync();

        return new GetProductsByCategoryResult(products);

    }
}
