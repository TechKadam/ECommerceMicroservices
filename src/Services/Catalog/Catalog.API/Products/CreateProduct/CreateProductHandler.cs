using BuildingBlocks.CQRS;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<CreateProductResponse>;

public record CreateProductResponse(Guid Id);
internal class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResponse>
{
    public Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // create Product entity from command object
        // save to database
        // return CreateProductResponse result
        throw new NotImplementedException();
    }
}
