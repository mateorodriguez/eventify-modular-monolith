using System.Runtime.InteropServices.JavaScript;
using Eventify.Modules.Events.Domain.Abstractions;
using Eventify.Modules.Events.Domain.Categories;
using FluentResults;

namespace Eventify.Modules.Events.Domain.Events;

public sealed class Event : Entity
{
    private Event()
    {
    }
    
    public Guid Id { get; private set; }
    public Guid CategoryId { get; set; }
    public string? Title { get; private set; }
    public string? Description { get; private set; }
    public string? Location { get; private set; }
    public DateTime StartsAtUtc { get; private set; }
    public DateTime? EndsAtUtc { get; private set; }
    public EventStatus Status { get; private set; }

    public static Result<Event> Create(
        Category category,
        string title,
        string description,
        string location,
        DateTime startsAtUtc,
        DateTime? endsAtUtc)
    {
        if (endsAtUtc < startsAtUtc)
        {
            return Result.Fail<Event>(EventErrors.StartDateIsAfterEndDateError);
        }
        
        Event anEvent = new()
        {
            Id = Guid.NewGuid(),
            CategoryId = category.Id,
            Title = title,
            Description = description,
            Location = location,
            StartsAtUtc = startsAtUtc,
            EndsAtUtc = endsAtUtc,
            Status = EventStatus.Draft
        };
        
        anEvent.Raise(new EventCreatedDomainEvent(anEvent.Id));
        
        return anEvent;
    }
}

