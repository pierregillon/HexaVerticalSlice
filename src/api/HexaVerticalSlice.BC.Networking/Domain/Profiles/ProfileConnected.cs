using HexaVerticalSlice.Api.BuildingBlocks.Events;

namespace HexaVerticalSlice.BC.Networking.Domain.Profiles;

public record ProfileConnected(ProfileId Id, ProfileId ProfileId) : IDomainEvent;