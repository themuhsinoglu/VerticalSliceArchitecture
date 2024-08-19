using MediatR;

namespace VerticalSliceArchitecture.API.Applications.Features.Products.GetProducts;

public class GetProductsQuery : IRequest<List<ProductResponse>>;