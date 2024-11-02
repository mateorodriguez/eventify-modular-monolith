namespace Eventify.Modules.Events.Domain.Abstractions;

public abstract class DomainEvent : IDomainEvent
{
    protected DomainEvent()
    {
    }

    protected DomainEvent(Guid id, DateTime occurredOnUtc)
    {
        Id = id;
        OccurredOnUtc = occurredOnUtc;
    }
    
    public Guid Id { get; }
    public DateTime OccurredOnUtc { get; }
}