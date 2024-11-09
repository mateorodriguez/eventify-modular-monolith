using Eventify.Modules.Events.Domain.Abstractions;
using FluentResults;

namespace Eventify.Modules.Events.Domain.TicketTypes;

public static class TicketTypeErrors
{
    public static IError NotFound(Guid ticketTypeId) => new DomainError(
        "TicketTypes.NotFound", 
        $"Ticket type with id: '{ticketTypeId}' was not found.");
}