using Eventify.Modules.Events.Application.Abstractions.Messaging;
using MediatR;

namespace Eventify.Modules.Events.Application.Events.GetEvent;

public sealed record GetEventQuery(Guid EventId) : IQuery<GetEventResponse?>;