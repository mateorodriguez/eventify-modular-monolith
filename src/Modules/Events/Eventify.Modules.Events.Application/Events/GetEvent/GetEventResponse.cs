using Eventify.Modules.Events.Application.TicketTypes.GetTicketType;

namespace Eventify.Modules.Events.Application.Events.GetEvent;

public sealed record GetEventResponse(
    Guid Id,
    Guid CategoryId,
    string Title,
    string Description,
    string Location,
    DateTime StartsAtUtc,
    DateTime? EndsAtUtc)
{
    public List<TicketTypeResponse> TicketTypes { get; set; } = [];
}

public sealed record TicketTypeResponse(
    Guid TicketTypeId,
    string Name,
    decimal Price,
    string Currency,
    decimal Quantity);