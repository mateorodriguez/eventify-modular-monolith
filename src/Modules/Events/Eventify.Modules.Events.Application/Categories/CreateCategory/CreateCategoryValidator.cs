using FluentValidation;

namespace Eventify.Modules.Events.Application.Categories.CreateCategory;

internal class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}