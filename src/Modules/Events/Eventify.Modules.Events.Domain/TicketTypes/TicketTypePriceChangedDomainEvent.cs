using Eventify.Modules.Events.Domain.Abstractions;

namespace Eventify.Modules.Events.Domain.TicketTypes;

public sealed class TicketTypePriceChangedDomainEvent(Guid ticketTypeId, decimal Price) : DomainEvent
{
    public Guid TicketTypeId { get; init; } = ticketTypeId;
}