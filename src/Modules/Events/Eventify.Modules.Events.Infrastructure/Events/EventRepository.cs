using Eventify.Modules.Events.Domain.Events;
using Eventify.Modules.Events.Infrastructure.Database;

namespace Eventify.Modules.Events.Infrastructure.Events;

internal sealed class EventRepository(EventsDbContext context) : IEventRepository
{
    public void Insert(Event @event)
    {
        context.Events.Add(@event);
    }
}