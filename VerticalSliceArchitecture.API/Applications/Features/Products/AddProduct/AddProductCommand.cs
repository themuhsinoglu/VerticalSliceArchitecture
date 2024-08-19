using MediatR;

namespace VerticalSliceArchitecture.API.Applications.Features.Products.AddProduct;

public class AddProductCommand : IRequest<AddProductResponse>
{
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public string Description { get; set; } = default!;
}