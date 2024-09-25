namespace HexaVerticalSlice.Api.BuildingBlocks.Events;

public interface IDomainEventPublisher
{
    Task Publish(IDomainEvent domainEvent);

    public async Task Publish(IEnumerable<IDomainEvent> domainEvents)
    {
        foreach (var domainEvent in domainEvents)
        {
            await Publish(domainEvent);
        }
    }
}