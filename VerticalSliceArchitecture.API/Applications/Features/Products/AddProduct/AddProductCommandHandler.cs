using MediatR;
using VerticalSliceArchitecture.API.Domain.Entities;
using VerticalSliceArchitecture.API.Infrastructure.Persistence;

namespace VerticalSliceArchitecture.API.Applications.Features.Products.AddProduct;

public class AddProductCommandHandler(AppDbContext context) : IRequestHandler<AddProductCommand, AddProductResponse>
{
    public async Task<AddProductResponse> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Price = request.Price,
            Description = request.Description
        };

        context.Products.Add(product);
        await context.SaveChangesAsync(cancellationToken);

        return new AddProductResponse(product.Id);
    }
}