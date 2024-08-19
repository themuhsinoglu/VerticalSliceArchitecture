using FluentValidation;

namespace VerticalSliceArchitecture.API.Applications.Features.Products.AddProduct;

public class AddProductValidator : AbstractValidator<AddProductCommand>
{
    public AddProductValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Product name is required.")
            .MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");

        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero.");

        RuleFor(p => p.Description)
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
    }
}