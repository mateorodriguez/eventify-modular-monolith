using Eventify.Modules.Events.Application.Events.SearchEvents;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Eventify.Modules.Events.Presentation.Events;

internal static class SearchEvents
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("events/search", async(
                ISender sender,
                Guid ? categoryId,
                DateTime? startDate,
                DateTime? endDate,
                int page = 0,
                int pageSize = 15) =>
            {
                Result<SearchEventsResponse> result = await sender.Send(
                    new SearchEventsQuery(categoryId, startDate, endDate, page, pageSize));

                return result.IsSuccess ? 
                    Results.Ok(result.Value) : 
                    ApiResults.ApiResults.Problem(result.ToResult());
            })
            .WithTags(Tags.Events);
    }
}