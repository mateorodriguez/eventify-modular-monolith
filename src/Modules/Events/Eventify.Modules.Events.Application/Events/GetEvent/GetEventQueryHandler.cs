using System.Data.Common;
using Dapper;
using Eventify.Modules.Events.Application.Abstractions;
using Eventify.Modules.Events.Application.Abstractions.Messaging;
using Eventify.Modules.Events.Application.TicketTypes.GetTicketType;
using Eventify.Modules.Events.Domain.Events;
using FluentResults;
using MediatR;

namespace Eventify.Modules.Events.Application.Events.GetEvent;

internal sealed class GetEventQueryHandler(IDbConnectionFactory dbConnectionFactory) 
    : IQueryHandler<GetEventQuery, GetEventResponse?>
{
    public async Task<Result<GetEventResponse>> Handle(GetEventQuery request, CancellationToken cancellationToken)
    {
        await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

        const string sql =
            $"""
             SELECT
                 e.id AS {nameof(GetEventResponse.Id)},
                 e.category_id AS {nameof(GetEventResponse.CategoryId)},
                 e.title AS {nameof(GetEventResponse.Title)},
                 e.description AS {nameof(GetEventResponse.Description)},
                 e.location AS {nameof(GetEventResponse.Location)},
                 e.starts_at_utc AS {nameof(GetEventResponse.StartsAtUtc)},
                 e.ends_at_utc AS {nameof(GetEventResponse.EndsAtUtc)},
                 tt.id AS {nameof(TicketTypeResponse.TicketTypeId)},
                 tt.name AS {nameof(TicketTypeResponse.Name)},
                 tt.price AS {nameof(TicketTypeResponse.Price)},
                 tt.currency AS {nameof(TicketTypeResponse.Currency)},
                 tt.quantity AS {nameof(TicketTypeResponse.Quantity)}
             FROM events.events e
             LEFT JOIN events.ticket_types tt ON tt.event_id = e.id
             WHERE e.id = @EventId
             """;

        Dictionary<Guid, GetEventResponse> eventsDictionary = [];
        await connection.QueryAsync<GetEventResponse, TicketTypeResponse?, GetEventResponse>(
            sql,
            (@event, ticketType) =>
            {
                if (eventsDictionary.TryGetValue(@event.Id, out GetEventResponse? existingEvent))
                {
                    @event = existingEvent;
                }
                else
                {
                    eventsDictionary.Add(@event.Id, @event);
                }

                if (ticketType is not null)
                {
                    @event.TicketTypes.Add(ticketType);
                }

                return @event;
            },
            request,
            splitOn: nameof(TicketTypeResponse.TicketTypeId));

        if (!eventsDictionary.TryGetValue(request.EventId, out GetEventResponse eventResponse))
        {
            return Result.Fail<GetEventResponse>(EventErrors.NotFound(request.EventId));
        }

        return eventResponse;
    }
}