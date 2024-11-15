using Eventify.Modules.Events.Application.Events.GetEvent;
using Eventify.Modules.Events.Domain.Abstractions;
using FluentResults;
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
                Result<GetEventResponse?> result = await sender.Send(new GetEventQuery(id));

                return result.IsSuccess ?
                    Results.Ok(result.Value) :
                    ApiResults.ApiResults.Problem(result.ToResult());
            })
            .WithTags(Tags.Events);
    }
}