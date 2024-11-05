namespace Eventify.Modules.Events.Application.Events.GetEvent;

public sealed record GetEventResponse(
    Guid Id,
    string Title,
    string Description,
    string Location,
    DateTime StartsAtUtc,
    DateTime? EndsAtUtc);