using MediatR;

namespace HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Commands;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : ICommand
{
    Task IRequestHandler<TCommand>.Handle(TCommand request, CancellationToken _) => Handle(request);

    Task Handle(TCommand command);
}

public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult>
    where TCommand : ICommand<TResult>
{
    Task<TResult> IRequestHandler<TCommand, TResult>.Handle(TCommand request, CancellationToken _) => Handle(request);

    Task<TResult> Handle(TCommand command);
}