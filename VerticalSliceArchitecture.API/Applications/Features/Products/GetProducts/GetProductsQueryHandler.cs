using MediatR;
using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.API.Infrastructure.Persistence;

namespace VerticalSliceArchitecture.API.Applications.Features.Products.GetProducts;

public class GetProductsQueryHandler(AppDbContext context) : IRequestHandler<GetProductsQuery, List<ProductResponse>>
{
    public async Task<List<ProductResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return await context.Products
            .Select(p => new ProductResponse(p.Id, p.Name, p.Price, p.Description))
            .ToListAsync(cancellationToken);
    }
}