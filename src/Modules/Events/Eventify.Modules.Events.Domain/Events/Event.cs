using System.Runtime.InteropServices.JavaScript;
using Eventify.Modules.Events.Domain.Abstractions;

namespace Eventify.Modules.Events.Domain.Events;

public sealed class Event : Entity
{
    private Event()
    {
    }
    
    public Guid Id { get; private set; }
    public string? Title { get; private set; }
    public string? Description { get; private set; }
    public string? Location { get; private set; }
    public DateTime StartsAtUtc { get; private set; }
    public DateTime? EndsAtUtc { get; private set; }
    public EventStatus Status { get; private set; }

    public static Event Create(string title,
        string description,
        string location,
        DateTime startsAtUtc,
        DateTime? endsAtUtc)
    {
        Event anEvent = new()
        {
            Id = Guid.NewGuid(),
            Title = title,
            Description = description,
            Location = location,
            StartsAtUtc = startsAtUtc,
            EndsAtUtc = endsAtUtc
        };
        
        anEvent.Raise(new EventCreatedDomainEvent(anEvent.Id));
        
        return anEvent;
    }
}

