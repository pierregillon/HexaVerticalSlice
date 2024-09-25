using HexaVerticalSlice.Api.BuildingBlocks.Aggregates;
using HexaVerticalSlice.BC.FeedDisplay.Features.Invite;

namespace HexaVerticalSlice.BC.FeedDisplay.Domain;

public class Profile : AggregateRoot<ProfileId>
{
    private readonly List<ProfileId> _connections = new();

    public IReadOnlyCollection<ProfileId> Connections => _connections;
    public ProfileId Id { get; }
    public string EmailAddress { get; }
    public Guid UserAccountId { get; }

    public static Profile Initialize(Guid userAccountId, string emailAddress) =>
        new(ProfileId.New(), emailAddress, userAccountId);

    public static Profile Rehydrate(ProfileId id, string emailAddress, Guid userAccountId) =>
        new(id, emailAddress, userAccountId);

    private Profile(ProfileId id, string emailAddress, Guid userAccountId) : base(id)
    {
        Id = id;
        EmailAddress = emailAddress;
        UserAccountId = userAccountId;
    }

    public Invitation Invite(Profile target, DateTime createdAt) =>
        Invitation.Create(Id, target.Id, createdAt);

    public void AddConnection(ProfileId profileId) =>
        _connections.Add(profileId);
}