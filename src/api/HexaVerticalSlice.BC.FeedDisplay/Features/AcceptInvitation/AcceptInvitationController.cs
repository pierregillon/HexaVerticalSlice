using System.ComponentModel.DataAnnotations;
using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Commands;
using HexaVerticalSlice.BC.FeedDisplay.Features.Invite;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HexaVerticalSlice.BC.FeedDisplay.Features.AcceptInvitation;

[Authorize]
[ApiController]
[Produces("application/json")]
public class AcceptInvitationController(ICommandDispatcher dispatcher)
    : ControllerBase
{
    [HttpPost("feed-display/v1/invitations/{invitationId}/accept")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AcceptInvitation([Required] [FromRoute] Guid invitationId)
    {
        var command = new AcceptInvitationCommand(InvitationId.Rehydrate(invitationId));

        await dispatcher.Dispatch(command);

        return Ok();
    }
}