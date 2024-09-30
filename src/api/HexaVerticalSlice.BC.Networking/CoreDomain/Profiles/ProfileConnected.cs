using HexaVerticalSlice.Api.BuildingBlocks.Events;

namespace HexaVerticalSlice.BC.Networking.CoreDomain.Profiles;

public record ProfileConnected(ProfileId Id, ProfileId ProfileId) : IDomainEvent;