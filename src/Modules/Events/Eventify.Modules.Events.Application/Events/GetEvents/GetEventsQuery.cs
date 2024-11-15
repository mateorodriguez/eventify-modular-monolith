using Eventify.Modules.Events.Application.Abstractions.Messaging;
using Eventify.Modules.Events.Application.Events.GetEvent;

namespace Eventify.Modules.Events.Application.Events.GetEvents;

public sealed record GetEventsQuery : IQuery<IReadOnlyCollection<EventResponse>>;