using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;

namespace HexaVerticalSlice.BC.FeedDisplay.Features.SearchForProfile;

public record SearchForProfileQuery(string EmailAddress) : IQuery<ProfileDto>;