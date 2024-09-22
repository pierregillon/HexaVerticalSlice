using System.Transactions;
using HexaVerticalSlice.BC.AccountManagement.Infra.Database;
using HexaVerticalSlice.BC.FeedDisplay.Infra;
using MediatR;

namespace HexaVerticalSlice;

internal class UnitOfWorkBehavior<TRequest, TResponse>(
    AccountManagementDbContext accountManagementDbContext,
    FeedDisplayDbContext feedDisplayDbContext
) : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        using var scope = BuildTransactionScope();

        var response = await next();

        await accountManagementDbContext.SaveChangesAsync(cancellationToken);
        await feedDisplayDbContext.SaveChangesAsync(cancellationToken);

        scope.Complete();

        return response;
    }

    private static TransactionScope BuildTransactionScope() =>
        new(
            TransactionScopeOption.Required,
            new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted },
            TransactionScopeAsyncFlowOption.Enabled
        );
}
