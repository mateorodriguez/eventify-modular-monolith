using Eventify.Modules.Events.Application.Abstractions;
using Eventify.Modules.Events.Domain.Events;
using MediatR;

namespace Eventify.Modules.Events.Application.Events.CreateEvent;

internal sealed class CreateEventCommandHandler(IEventRepository repository, IUnitOfWork unitOfWork) 
    : IRequestHandler<CreateEventCommand, Guid>
{
    public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    { 
        var newEvent = Event.Create(
            request.Title,
            request.Description,
            request.Location,
            request.StartAtUtc,
            request.EndAtUtc); 
        
        repository.Insert(newEvent);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return newEvent.Id;
    }
}