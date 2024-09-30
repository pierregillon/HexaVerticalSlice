using MediatR;

namespace HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Commands;

public interface ICommand : IRequest;

public interface ICommand<out TResult> : IRequest<TResult>;
