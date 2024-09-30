using MediatR;

namespace HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Commands;

public interface ICancellableCommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : ICommand;