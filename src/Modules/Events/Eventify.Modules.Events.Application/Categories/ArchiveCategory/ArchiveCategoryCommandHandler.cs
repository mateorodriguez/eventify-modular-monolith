using Eventify.Modules.Events.Application.Abstractions;
using Eventify.Modules.Events.Application.Abstractions.Messaging;
using Eventify.Modules.Events.Domain.Categories;
using FluentResults;

namespace Eventify.Modules.Events.Application.Categories.ArchiveCategory;

internal sealed class ArchiveCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork) 
    : ICommandHandler<ArchiveCategoryCommand>
{
    public async Task<Result> Handle(ArchiveCategoryCommand request, CancellationToken cancellationToken)
    {
        Category? category = await categoryRepository.GetAsync(request.CategoryId,  cancellationToken);

        if (category is null)
        {
            return Result.Fail(CategoryErrors.NotFound(request.CategoryId));
        }

        if (category.IsArchived)
        {
            return Result.Fail(CategoryErrors.AlreadyArchived);
        }
        
        category.Archive();
        
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}