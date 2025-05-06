using BuildingBlocks.CQRS;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);
internal class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public Task<CreateProductResult> HandleAsync(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // create Product entity from command object
        // save to database
        // return CreateProductResponse result
        throw new NotImplementedException();
    }
}
