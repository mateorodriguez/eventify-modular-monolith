using Eventify.Modules.Events.Application.Categories.GetCategory;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Eventify.Modules.Events.Presentation.Categories;

internal static class GetCategory
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("categories/{id}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
            {
                Result<CategoryResponse> result = await sender.Send(new GetCategoryQuery(id),  cancellationToken);
                
                return result.IsSuccess ? 
                    Results.Ok(result.Value) : 
                    ApiResults.ApiResults.Problem(result.ToResult());
            })
            .WithTags(Tags.Categories);
    }
}