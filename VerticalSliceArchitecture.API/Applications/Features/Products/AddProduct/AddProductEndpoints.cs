using MediatR;

namespace VerticalSliceArchitecture.API.Applications.Features.Products.AddProduct;

public static class AddProductEndpoints
{
    public static void MapAddProductEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/products", async (IMediator mediator, AddProductCommand command) =>
            {
                var productId = await mediator.Send(command);
                return Results.Ok(productId);
            })
            .WithName("AddProduct")
            .WithTags("Products");
    }
}