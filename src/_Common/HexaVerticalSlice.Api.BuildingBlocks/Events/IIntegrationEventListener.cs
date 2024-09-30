using MediatR;

namespace HexaVerticalSlice.Api.BuildingBlocks.Events;

public interface IIntegrationEventListener<in TIntegrationEvent> : INotificationHandler<TIntegrationEvent>
    where TIntegrationEvent : IIntegrationEvent
{
    Task INotificationHandler<TIntegrationEvent>.Handle(TIntegrationEvent notification, CancellationToken _) =>
        On(notification);

    Task On(TIntegrationEvent integrationEvent);
}