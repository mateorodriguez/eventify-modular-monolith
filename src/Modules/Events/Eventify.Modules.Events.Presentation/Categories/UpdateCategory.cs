using Eventify.Modules.Events.Application.Categories.UpdateCategory;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Eventify.Modules.Events.Presentation.Categories;

internal static class UpdateCategory
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("categories/{id:guid}",
                async (Guid id, Request request, ISender sender, CancellationToken cancellationToken) =>
                {
                    Result result = await sender.Send(new UpdateCategoryCommand(id, request.Name), cancellationToken);
                    
                    return result.IsSuccess ?
                        Results.Ok() :
                        ApiResults.ApiResults.Problem(result);
                })
            .WithTags(Tags.Categories);
    }

    internal sealed class Request
    {
        public string Name { get; init; }
    }
}