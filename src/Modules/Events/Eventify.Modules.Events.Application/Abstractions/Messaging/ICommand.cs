using FluentResults;
using MediatR;

namespace Eventify.Modules.Events.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>, IBaseCommand;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;
public interface IBaseCommand;