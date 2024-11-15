using Eventify.Modules.Events.Application.Abstractions.Messaging;

namespace Eventify.Modules.Events.Application.Events.CancelEvent;

public record CancelEventCommand(Guid EventId) : ICommand;