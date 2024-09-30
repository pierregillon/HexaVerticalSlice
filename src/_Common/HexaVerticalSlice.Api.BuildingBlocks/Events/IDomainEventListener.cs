using MediatR;

namespace HexaVerticalSlice.Api.BuildingBlocks.Events;

public interface IDomainEventListener<in TDomainEvent> : INotificationHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent
{
    Task INotificationHandler<TDomainEvent>.Handle(TDomainEvent notification, CancellationToken _) => On(notification);

    Task On(TDomainEvent domainEvent);
}