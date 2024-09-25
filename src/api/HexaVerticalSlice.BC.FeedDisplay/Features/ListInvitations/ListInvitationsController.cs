using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HexaVerticalSlice.BC.FeedDisplay.Features.ListInvitations;

[Authorize]
[ApiController]
[Produces("application/json")]
public class ListInvitationsController(IQueryDispatcher dispatcher)
    : ControllerBase
{
    [HttpGet("feed-display/v1/invitations")]
    [ProducesResponseType(typeof(IReadOnlyCollection<InvitationDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> List()
    {
        var query = new ListInvitationsQuery();

        var results = await dispatcher.Dispatch(query);

        return Ok(results);
    }
}