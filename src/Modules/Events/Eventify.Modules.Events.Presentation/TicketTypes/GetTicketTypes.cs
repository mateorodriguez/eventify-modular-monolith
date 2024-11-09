using Eventify.Modules.Events.Application.TicketTypes.GetTicketType;
using Eventify.Modules.Events.Application.TicketTypes.GetTicketTypes;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Eventify.Modules.Events.Presentation.TicketTypes;

internal static class GetTicketTypes
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("ticket-types", async (Guid eventId, ISender sender) =>
            {
                Result<IReadOnlyCollection<TicketTypeResponse>> result = await sender.Send(
                    new GetTicketTypesQuery(eventId));

                return result.IsSuccess ? 
                    Results.Ok(result.Value) : 
                    ApiResults.ApiResults.Problem(result.ToResult());
            })
            .WithTags(Tags.TicketTypes);
    }
}