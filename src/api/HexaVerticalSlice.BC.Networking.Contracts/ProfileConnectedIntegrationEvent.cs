using HexaVerticalSlice.Api.BuildingBlocks.Events;

namespace HexaVerticalSlice.BC.Networking.Contracts;

public record ProfileConnectedIntegrationEvent(
    Guid ProfileId,
    Guid UserId,
    Guid SecondProfileId,
    Guid ConnectedUserId
) : IIntegrationEvent;