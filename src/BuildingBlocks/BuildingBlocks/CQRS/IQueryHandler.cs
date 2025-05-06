using Mediator.Abstractions;

namespace BuildingBlocks.CQRS;


public interface IQueryHandler<in TQuery> : IRequestHandler<TQuery, Unit> where TQuery : class, IQuery<Unit>
{
}

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse> where TQuery : class, IQuery<TResponse>
    where TResponse : notnull
{
}

