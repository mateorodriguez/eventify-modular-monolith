using System.Data.Common;
using Dapper;
using Eventify.Modules.Events.Application.Abstractions;
using MediatR;

namespace Eventify.Modules.Events.Application.Events.GetEvent;

public sealed class GetEventQueryHandler(IDbConnectionFactory dbConnectionFactory) 
    : IRequestHandler<GetEventQuery, GetEventResponse?>
{
    public async Task<GetEventResponse?> Handle(GetEventQuery request, CancellationToken cancellationToken)
    {
        await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

        const string sql = 
            $"""
             SELECT
                 id AS {nameof(GetEventResponse.Id)},
                 title AS {nameof(GetEventResponse.Title)},
                 description AS {nameof(GetEventResponse.Description)},
                 location AS {nameof(GetEventResponse.Location)},
                 starts_at_utc AS {nameof(GetEventResponse.StartsAtUtc)},
                 ends_at_utc AS {nameof(GetEventResponse.EndsAtUtc)}
             FROM events.events
             WHERE id = @EventId
             """;
        
        GetEventResponse? theEvent = await connection.QuerySingleOrDefaultAsync<GetEventResponse>(sql, request);
        
        return theEvent;
    }
}