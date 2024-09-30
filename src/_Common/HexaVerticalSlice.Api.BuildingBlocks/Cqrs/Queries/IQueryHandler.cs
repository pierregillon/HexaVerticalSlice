using MediatR;

namespace HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;

public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
{
    Task<TResult> IRequestHandler<TQuery, TResult>.Handle(TQuery request, CancellationToken _) => Handle(request);

    Task<TResult> Handle(TQuery query);
}