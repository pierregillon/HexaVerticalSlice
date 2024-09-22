namespace HexaVerticalSlice.Api.BuildingBlocks.Aggregates;

public interface IRepository<TAggregate, in TAggregateId>
    where TAggregate : IAggregateRoot<TAggregateId>
    where TAggregateId : IAggregateId
{
    Task Save(TAggregate category);
    Task<TAggregate> Get(TAggregateId id);
}