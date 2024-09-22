namespace HexaVerticalSlice.Api.BuildingBlocks.Aggregates;

public interface IAggregateRoot<TId>
    where TId : IAggregateId
{
    IEnumerable<IDomainEvent> UncommittedChanges { get; }
    void MarkAsCommitted();
}