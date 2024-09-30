namespace HexaVerticalSlice.Api.BuildingBlocks.Aggregates;

public static class RepositoryExtensions
{
    public static async Task Save<TAggregate, TAggregateId>(
        this IRepository<TAggregate, TAggregateId> repository,
        IEnumerable<TAggregate> aggregates
    )
        where TAggregate : IAggregateRoot<TAggregateId>
        where TAggregateId : IAggregateId
    {
        foreach (var aggregate in aggregates)
        {
            await repository.Save(aggregate);
        }
    }

    public static async Task Execute<TAggregate, TAggregateId>(
        this IRepository<TAggregate, TAggregateId> repository,
        TAggregateId aggregateId,
        Action<TAggregate> action
    )
        where TAggregate : IAggregateRoot<TAggregateId>
        where TAggregateId : IAggregateId
    {
        var aggregate = await repository.Get(aggregateId);

        action(aggregate);

        await repository.Save(aggregate);
    }

    public static async IAsyncEnumerable<TAggregate> GetAll<TAggregate, TAggregateId>(
        this IRepository<TAggregate, TAggregateId> repository,
        IEnumerable<TAggregateId> aggregateIds
    )
        where TAggregate : IAggregateRoot<TAggregateId>
        where TAggregateId : IAggregateId
    {
        foreach (var aggregateId in aggregateIds)
        {
            yield return await repository.Get(aggregateId);
        }
    }
}