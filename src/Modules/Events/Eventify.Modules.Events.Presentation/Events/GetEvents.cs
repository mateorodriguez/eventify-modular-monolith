using Eventify.Modules.Events.Application.Events.GetEvents;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Eventify.Modules.Events.Presentation.Events;

internal static class GetEvents
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("events", async (ISender sender) =>
            {
                Result<IReadOnlyCollection<EventResponse>> result = await sender.Send(new GetEventsQuery());
                
                return result.IsSuccess ? 
                    Results.Ok(result.Value) : 
                    ApiResults.ApiResults.Problem(result.ToResult());
            })
            .WithTags(Tags.Events);
    }
}