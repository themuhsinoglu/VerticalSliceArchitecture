using VerticalSliceArchitecture.API.Applications.Features.Products.AddProduct;
using VerticalSliceArchitecture.API.Applications.Features.Products.GetProducts;

namespace VerticalSliceArchitecture.API.Applications.Features.Products.Extensions;

public static class ProductServiceExtension
{
    public static void AddProductServices(this WebApplication app)
    {
        app.MapAddProductEndpoints();

        app.MapGetProductsEndpoints();
    }
}