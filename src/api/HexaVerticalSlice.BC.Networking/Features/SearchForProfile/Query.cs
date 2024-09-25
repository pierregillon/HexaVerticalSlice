using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;

namespace HexaVerticalSlice.BC.Networking.Features.SearchForProfile;

public record SearchForProfileQuery(string EmailAddress) : IQuery<ProfileDto>;