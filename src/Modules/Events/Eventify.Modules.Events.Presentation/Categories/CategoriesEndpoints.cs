using Microsoft.AspNetCore.Routing;

namespace Eventify.Modules.Events.Presentation.Categories;

public static class CategoriesEndpoints
{
    public static IEndpointRouteBuilder MapCategoriesEndpoints(this IEndpointRouteBuilder builder)
    {
        CreateCategory.MapEndpoint(builder);
        GetCategory.MapEndpoint(builder);
        
        return builder;
    }
}