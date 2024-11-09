using Eventify.Modules.Events.Application.Categories.ArchiveCategory;
using Eventify.Modules.Events.Application.Categories.GetCategoriesQuery;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Eventify.Modules.Events.Presentation.Categories;

internal static class ArchiveCategory
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("categories/{id:guid}/archive", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            Result result = await sender.Send(new ArchiveCategoryCommand(id), cancellationToken);
            
            return result.IsSuccess ?
                Results.Ok() :
                ApiResults.ApiResults.Problem(result);
        })
        .WithTags(Tags.Categories);
    }
}