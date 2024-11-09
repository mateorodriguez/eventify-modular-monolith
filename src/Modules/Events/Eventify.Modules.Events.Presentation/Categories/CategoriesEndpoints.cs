using Microsoft.AspNetCore.Routing;

namespace Eventify.Modules.Events.Presentation.Categories;

public static class CategoriesEndpoints
{
    public static IEndpointRouteBuilder MapCategoriesEndpoints(this IEndpointRouteBuilder builder)
    {
        CreateCategory.MapEndpoint(builder);
        GetCategory.MapEndpoint(builder);
        GetCategories.MapEndpoint(builder);
        ArchiveCategory.MapEndpoint(builder);
        UpdateCategory.MapEndpoint(builder);
        
        return builder;
    }
}