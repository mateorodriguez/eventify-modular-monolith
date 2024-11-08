using FluentResults;
using MediatR;

namespace Eventify.Modules.Events.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;