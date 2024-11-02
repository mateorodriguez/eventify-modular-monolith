using Eventify.Modules.Events.Domain.Abstractions;

namespace Eventify.Modules.Events.Domain.Events;

public class EventCreatedDomainEvent(Guid eventId) : DomainEvent
{
    public Guid EventId { get; init; }   
}