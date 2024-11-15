using Eventify.Modules.Events.Application.Events.CancelEvent;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Eventify.Modules.Events.Presentation.Events;

internal static class CancelEvent
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("events/{id}/cancel", async (Guid id, ISender sender) =>
            {
                Result result = await sender.Send(new CancelEventCommand(id));

                return result.IsSuccess ? 
                    Results.NoContent() : 
                    ApiResults.ApiResults.Problem(result);
            })
            .WithTags(Tags.Events);
    }
}