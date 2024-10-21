using MediatR;
using FluentValidation;

namespace VerticalSliceArchitecture.API.Applications.Features.Products.AddProduct;

public static class AddProductEndpoints
{
    public static void MapAddProductEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/products", async (IMediator mediator, AddProductCommand command, IValidator<AddProductCommand> validator) =>
            {

                var validationResult = await validator.ValidateAsync(command);

                if (!validationResult.IsValid)
                {
                    return Results.ValidationProblem(validationResult.ToDictionary());
                }

                var productId = await mediator.Send(command);
                return Results.Ok(productId);
            })
            .WithName("AddProduct")
            .WithTags("Products");
    }
}