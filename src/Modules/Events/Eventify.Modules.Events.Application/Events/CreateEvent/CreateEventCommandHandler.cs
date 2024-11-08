using Eventify.Modules.Events.Application.Abstractions;
using Eventify.Modules.Events.Application.Abstractions.Clock;
using Eventify.Modules.Events.Application.Abstractions.Messaging;
using Eventify.Modules.Events.Domain.Categories;
using Eventify.Modules.Events.Domain.Events;
using FluentResults;
using MediatR;

namespace Eventify.Modules.Events.Application.Events.CreateEvent;

internal sealed class CreateEventCommandHandler(
    IDateTimeProvider dateTimeProvider,
    IEventRepository repository, 
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork) 
    : ICommandHandler<CreateEventCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        if (request.StartAtUtc < dateTimeProvider.UtcNow)
        {
            return Result.Fail<Guid>(EventErrors.StartDateIsInThePast);
        }
        
        Category? category = await categoryRepository.GetAsync(request.CategoryId, cancellationToken);

        if (category is null)
        {
            return Result.Fail<Guid>(CategoryErrors.NotFound(request.CategoryId));
        }
        
        Result<Event> result = Event.Create(
            category,
            request.Title,
            request.Description,
            request.Location,
            request.StartAtUtc,
            request.EndAtUtc);

        if (result.IsFailed)
        {
            return result.ToResult<Guid>();
        }
        
        repository.Insert(result.Value);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return result.Value.Id;
    }
}