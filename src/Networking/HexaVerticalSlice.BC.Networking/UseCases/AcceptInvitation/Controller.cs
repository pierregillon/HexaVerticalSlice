using System.ComponentModel.DataAnnotations;
using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Commands;
using HexaVerticalSlice.BC.Networking.CoreDomain.Invitations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HexaVerticalSlice.BC.Networking.UseCases.AcceptInvitation;

[Authorize]
[ApiController]
[Produces("application/json")]
public class NetworkingController(ICommandDispatcher dispatcher)
    : ControllerBase
{
    [HttpPost("networking/v1/invitations/{invitationId}/accept")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AcceptInvitation([Required] [FromRoute] Guid invitationId)
    {
        var command = new AcceptInvitationCommand(InvitationId.Rehydrate(invitationId));

        await dispatcher.Dispatch(command);

        return Ok();
    }
}