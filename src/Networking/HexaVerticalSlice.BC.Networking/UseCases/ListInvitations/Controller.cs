using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HexaVerticalSlice.BC.Networking.UseCases.ListInvitations;

[Authorize]
[ApiController]
[Produces("application/json")]
public class NetworkingController(IQueryDispatcher dispatcher)
    : ControllerBase
{
    [HttpGet("networking/v1/invitations")]
    [ProducesResponseType(typeof(IReadOnlyCollection<InvitationDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> List()
    {
        var query = new ListInvitationsQuery();

        var results = await dispatcher.Dispatch(query);

        return Ok(results);
    }
}