using System.ComponentModel.DataAnnotations;
using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Commands;
using HexaVerticalSlice.BC.Networking.CoreDomain.Profiles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HexaVerticalSlice.BC.Networking.UseCases.Invite;

[Authorize]
[ApiController]
[Produces("application/json")]
public class NetworkingController(ICommandDispatcher dispatcher)
    : ControllerBase
{
    [HttpPost("networking/v1/profiles/{profileId}/invite")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Invite([Required] [FromRoute] Guid profileId)
    {
        var command = new InviteCommand(ProfileId.Rehydrate(profileId));

        var invitationId = await dispatcher.Dispatch(command);

        return Ok(invitationId.Value);
    }
}