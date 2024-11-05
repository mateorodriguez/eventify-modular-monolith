using Eventify.Modules.Events.Application.Events.GetEvent;
using Eventify.Modules.Events.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Eventify.Modules.Events.Presentation.Events;

internal static class GetEvent
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("events/{id}", async (Guid id, ISender sender) =>
            {
                GetEventResponse? response = await sender.Send(new GetEventQuery(id));

                return response is null ? Results.NotFound() : Results.Ok(response);
            })
            .WithTags(Tags.Events);
    }
}