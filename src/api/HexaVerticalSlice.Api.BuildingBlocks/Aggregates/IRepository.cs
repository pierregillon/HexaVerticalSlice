namespace HexaVerticalSlice.Api.BuildingBlocks.Aggregates;

public interface IRepository<TAggregate, in TAggregateId>
    where TAggregate : IAggregateRoot<TAggregateId>
    where TAggregateId : IAggregateId
{
    Task Save(TAggregate aggregate);
    Task<TAggregate> Get(TAggregateId id);

    public async Task Save(params TAggregate[] aggregates)
    {
        foreach (var aggregate in aggregates)
        {
            await Save(aggregate);
        }
    }
}