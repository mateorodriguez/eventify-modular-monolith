using Eventify.Modules.Events.Domain.Abstractions;

namespace Eventify.Modules.Events.Domain.Events;

public sealed class EventRescheduledDomainEvent(Guid eventId, DateTime startsAtUtc, DateTime? endsAtUtc)
    : DomainEvent
{
    public Guid EventId { get; } = eventId;
    public DateTime StartsAtUtc { get; } = startsAtUtc;
    public DateTime? EndsAtUtc { get; } = endsAtUtc;
}
