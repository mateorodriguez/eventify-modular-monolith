using Eventify.Modules.Events.Application.Abstractions.Messaging;
using Eventify.Modules.Events.Application.Categories.GetCategory;

namespace Eventify.Modules.Events.Application.Categories.GetCategoriesQuery;

public sealed record GetCategoriesQuery : IQuery<IReadOnlyCollection<CategoryResponse>>;