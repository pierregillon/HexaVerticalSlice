using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;

namespace HexaVerticalSlice.BC.Networking.UseCases.SearchForProfile;

public record SearchForProfileQuery(string EmailAddress) : IQuery<ProfileDto>;