using Eventify.Modules.Events.Domain.Abstractions;
using FluentResults;

namespace Eventify.Modules.Events.Domain.Categories;

public static class CategoryErrors
{
    public static IError NotFound(Guid categoryId) => new DomainError(
        "Categories.NotFound", 
        $"Category with id: '{categoryId}' was not found.");
    
    public static readonly IError AlreadyArchived = new DomainError(
        "Categories.AlreadyArchived",
        "The category is already archived.");
}