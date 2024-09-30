namespace HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;

public interface IQueryDispatcher
{
    Task<TResult> Dispatch<TResult>(IQuery<TResult> query, CancellationToken token = default);
}