using Mediator.Abstractions;

namespace BuildingBlocks.CQRS;


public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Unit> where TCommand : class, ICommand<Unit>
{
}

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse> where TCommand : class, ICommand<TResponse> where TResponse : notnull
{
}


