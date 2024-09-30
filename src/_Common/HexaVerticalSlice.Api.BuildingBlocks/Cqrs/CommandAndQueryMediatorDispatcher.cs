using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Commands;
using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;
using MediatR;

namespace HexaVerticalSlice.Api.BuildingBlocks.Cqrs;

internal class CommandAndQueryMediatorDispatcher(ISender sender) 
    : ICommandDispatcher, IQueryDispatcher
{
    public Task Dispatch<TCommand>(TCommand command, CancellationToken token = default) where TCommand : ICommand => 
        sender.Send(command, token);

    public Task<TResult> Dispatch<TResult>(ICommand<TResult> command, CancellationToken token = default) => 
        sender.Send(command, token);

    public Task<TResult> Dispatch<TResult>(IQuery<TResult> query, CancellationToken token = default) => 
        sender.Send(query, token);
}