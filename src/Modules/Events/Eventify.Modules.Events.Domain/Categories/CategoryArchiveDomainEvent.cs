using Eventify.Modules.Events.Domain.Abstractions;

namespace Eventify.Modules.Events.Domain.Categories;

public sealed class CategoryArchiveDomainEvent(Guid categoryId) : DomainEvent
{
    public Guid CategoryId { get; init; } = categoryId;
}