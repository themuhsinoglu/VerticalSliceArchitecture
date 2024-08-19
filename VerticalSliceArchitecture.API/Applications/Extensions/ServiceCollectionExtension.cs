using VerticalSliceArchitecture.API.Applications.Features.Products.Extensions;

namespace VerticalSliceArchitecture.API.Applications.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddEndpoints(this WebApplication app)
    {
        app.AddProductServices();
    }
}