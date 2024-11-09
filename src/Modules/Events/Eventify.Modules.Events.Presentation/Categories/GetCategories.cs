using Eventify.Modules.Events.Application.Categories.GetCategoriesQuery;
using Eventify.Modules.Events.Application.Categories.GetCategory;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Eventify.Modules.Events.Presentation.Categories;

internal static class GetCategories
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("categories", async (ISender sender) =>
            {
                Result<IReadOnlyCollection<CategoryResponse>> result = 
                    await sender.Send(new GetCategoriesQuery());
            
                return result.IsSuccess ? 
                    Results.Ok(result.Value) : 
                    ApiResults.ApiResults.Problem(result.ToResult());
            })
            .WithTags(Tags.Categories);
    }
}