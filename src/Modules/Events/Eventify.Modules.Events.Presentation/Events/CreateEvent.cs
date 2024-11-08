using Eventify.Modules.Events.Application.Events.CreateEvent;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Eventify.Modules.Events.Presentation.Events;

internal static class CreateEvent
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("events", async ([FromBody] Request request, ISender sender) =>
            {
                Result<Guid> result = await sender.Send(new CreateEventCommand(
                    request.CategoryId,
                    request.Title,
                    request.Description,
                    request.Location,
                    request.StartsAtUtc,
                    request.EndsAtUtc));

                return result.IsSuccess ? 
                    Results.Ok(result.Value) : 
                    ApiResults.ApiResults.Problem(result.ToResult());
            })
            .WithTags(Tags.Events);
    }

    internal sealed class Request
    {
        public Guid CategoryId { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public string Location { get; init; }
        public DateTime StartsAtUtc { get; init; }
        public DateTime? EndsAtUtc { get; init; }
    }
}