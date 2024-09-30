namespace HexaVerticalSlice.Api.BuildingBlocks.Events;

public interface IIntegrationEventPublisher
{
    Task Publish(IIntegrationEvent integrationEvent);
}