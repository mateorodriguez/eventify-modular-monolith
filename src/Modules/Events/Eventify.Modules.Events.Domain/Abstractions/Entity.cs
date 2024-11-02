namespace Eventify.Modules.Events.Domain.Abstractions;

public class Entity
{
    private readonly List<IDomainEvent> _domainEvents = [];
    
    protected Entity() { }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void Raise(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}