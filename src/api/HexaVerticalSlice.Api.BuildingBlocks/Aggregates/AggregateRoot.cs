using HexaVerticalSlice.Api.BuildingBlocks.Events;

namespace HexaVerticalSlice.Api.BuildingBlocks.Aggregates;

public abstract class AggregateRoot<TId>(TId accountId) : IAggregateRoot<TId>
    where TId : IAggregateId
{
    private readonly List<IDomainEvent> _uncommittedDomainEvents = new();

    public IEnumerable<IDomainEvent> UncommittedChanges => _uncommittedDomainEvents;

    public TId AccountId { get; } = accountId;

    protected void ApplyEvent(IDomainEvent domainEvent) =>
        _uncommittedDomainEvents.Add(domainEvent);

    public void MarkAsCommitted() => _uncommittedDomainEvents.Clear();
}