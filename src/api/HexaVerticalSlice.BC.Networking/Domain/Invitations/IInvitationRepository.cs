using HexaVerticalSlice.Api.BuildingBlocks.Aggregates;

namespace HexaVerticalSlice.BC.Networking.Domain.Invitations;

public interface IInvitationRepository : IRepository<Invitation, InvitationId>;