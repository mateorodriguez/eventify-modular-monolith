using Eventify.Modules.Events.Application.Abstractions;
using Eventify.Modules.Events.Application.Abstractions.Messaging;
using Eventify.Modules.Events.Domain.Events;
using Eventify.Modules.Events.Domain.TicketTypes;
using FluentResults;

namespace Eventify.Modules.Events.Application.TicketTypes.CreateTicketType;

internal sealed class CreateTicketTypeCommandHandler(
    IEventRepository eventRepository,
    ITicketTypeRepository ticketTypeRepository,
    IUnitOfWork unitOfWork) 
    : ICommandHandler<CreateTicketTypeCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateTicketTypeCommand request, CancellationToken cancellationToken)
    {
        Event? @event = await eventRepository.GetAsync(request.EventId,  cancellationToken);

        if (@event is null)
        {
            return Result.Fail<Guid>(EventErrors.NotFound(request.EventId));
        }
        
        var ticketType = TicketType.Create(
            @event,
            request.Name,
            request.Price,
            request.Currency,
            request.Quantity);
        
        ticketTypeRepository.Insert(ticketType);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return ticketType.Id;
    }
}