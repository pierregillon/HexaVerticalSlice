using MediatR;

namespace HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;

public interface IQuery<out TResult> : IRequest<TResult>;