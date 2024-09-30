using HexaVerticalSlice.Api.BuildingBlocks.Events;

namespace HexaVerticalSlice.BC.AccountManagement.Contracts;

public record UserAccountRegisteredIntegrationEvent(Guid UserAccountId, string EmailAddress) : IIntegrationEvent;