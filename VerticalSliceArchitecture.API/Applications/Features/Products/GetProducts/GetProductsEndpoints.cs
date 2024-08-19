using MediatR;

namespace VerticalSliceArchitecture.API.Applications.Features.Products.GetProducts;

public static class GetProductsEndpoints
{
    public static void MapGetProductsEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/products", async (IMediator mediator) =>
            {
                var query = new GetProductsQuery();
                var products = await mediator.Send(query);
                return Results.Ok(products);
            })
            .WithName("GetProducts")
            .WithTags("Products");
    }
}