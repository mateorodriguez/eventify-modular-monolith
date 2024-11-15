using System.Data.Common;
using Dapper;
using Eventify.Modules.Events.Application.Abstractions;
using Eventify.Modules.Events.Application.Abstractions.Messaging;
using FluentResults;

namespace Eventify.Modules.Events.Application.Events.GetEvents;

internal sealed class GetEventsQueryHandler(IDbConnectionFactory dbConnectionFactory) 
    : IQueryHandler<GetEventsQuery, IReadOnlyCollection<EventResponse>>
{
    public async Task<Result<IReadOnlyCollection<EventResponse>>> Handle(
        GetEventsQuery request, CancellationToken cancellationToken)
    {
        await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

        const string sql =
            $"""
             SELECT
                 id AS {nameof(EventResponse.Id)},
                 category_id AS {nameof(EventResponse.CategoryId)},
                 title AS {nameof(EventResponse.Title)},
                 description AS {nameof(EventResponse.Description)},
                 location AS {nameof(EventResponse.Location)},
                 starts_at_utc AS {nameof(EventResponse.StartsAtUtc)},
                 ends_at_utc AS {nameof(EventResponse.EndsAtUtc)}
             FROM events.events
             """;
        
        return (await connection.QueryAsync<EventResponse>(sql, request)).AsList();;
    }
}