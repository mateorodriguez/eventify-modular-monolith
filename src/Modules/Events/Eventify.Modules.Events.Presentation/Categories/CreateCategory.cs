using Eventify.Modules.Events.Application.Categories.CreateCategory;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Eventify.Modules.Events.Presentation.Categories;

internal static class CreateCategory
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("categories", async (Request request, ISender sender, CancellationToken cancellationToken) =>
        {
            Result<Guid> result = await sender.Send(new CreateCategoryCommand(request.Name), cancellationToken);
            
            return result.IsSuccess ?
                Results.Created($"categories/{result.Value}", result.Value) :
                ApiResults.ApiResults.Problem(result.ToResult());
        })
        .WithTags(Tags.Categories);
    }

    internal sealed class Request
    {
        public string Name { get; init; }
    }
}