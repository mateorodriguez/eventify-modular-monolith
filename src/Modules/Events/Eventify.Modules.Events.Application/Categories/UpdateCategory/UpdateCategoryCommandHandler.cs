using Eventify.Modules.Events.Application.Abstractions;
using Eventify.Modules.Events.Application.Abstractions.Messaging;
using Eventify.Modules.Events.Domain.Categories;
using FluentResults;

namespace Eventify.Modules.Events.Application.Categories.UpdateCategory;

internal sealed class UpdateCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork) 
    : ICommandHandler<UpdateCategoryCommand>
{
    public async Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    { 
        Category? category = await categoryRepository.GetAsync(request.CategoryId, cancellationToken);

        if (category is null)
        {
            return Result.Fail(CategoryErrors.NotFound(request.CategoryId));
        }
        
        category.ChangeName(request.Name);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Ok();
    }
}