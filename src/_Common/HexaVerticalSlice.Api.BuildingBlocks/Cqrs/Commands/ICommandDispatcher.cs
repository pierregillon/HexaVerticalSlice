namespace HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Commands;

public interface ICommandDispatcher
{
    Task Dispatch<TCommand>(TCommand command, CancellationToken token = default) where TCommand : ICommand;
    Task<TResult> Dispatch<TResult>(ICommand<TResult> command, CancellationToken token = default);
}