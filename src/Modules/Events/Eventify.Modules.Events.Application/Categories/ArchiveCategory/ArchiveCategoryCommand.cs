using Eventify.Modules.Events.Application.Abstractions.Messaging;
using MediatR;

namespace Eventify.Modules.Events.Application.Categories.ArchiveCategory;

public sealed record ArchiveCategoryCommand(Guid CategoryId) : ICommand;