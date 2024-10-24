using MediatR;
using VerticalSliceArchitecture.API.Applications.Abstracts;
using VerticalSliceArchitecture.API.Domain.Entities;
using VerticalSliceArchitecture.API.Infrastructure.Persistence.Contexts;

namespace VerticalSliceArchitecture.API.Applications.Features.Products.AddProduct;

public class AddProductCommandHandler(AppDbContext context, IUnitOfWork _unitOfWork) : IRequestHandler<AddProductCommand, AddProductResponse>
{
    public async Task<AddProductResponse> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Price = request.Price,
            Description = request.Description
        };
        _unitOfWork.BeginTransaction();

        await _unitOfWork.GetRepository<Product>().AddAsync(product);

        await _unitOfWork.CompleteAsync();

        _unitOfWork.CommitTransaction();

        //context.Products.Add(product);
        //await context.SaveChangesAsync(cancellationToken);

        return new AddProductResponse(product.Id);
    }
}