using MediatR;

namespace Eventify.Modules.Events.Application.Events.CreateEvent;

public sealed record CreateEventCommand(
    string Title,
    string Description,
    string Location,
    DateTime StartAtUtc,
    DateTime? EndAtUtc) : IRequest<Guid>;