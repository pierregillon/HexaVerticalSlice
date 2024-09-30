using HexaVerticalSlice.Api.BuildingBlocks.Aggregates;

namespace HexaVerticalSlice.BC.Networking.CoreDomain.Invitations;

public interface IInvitationRepository : IRepository<Invitation, InvitationId>;