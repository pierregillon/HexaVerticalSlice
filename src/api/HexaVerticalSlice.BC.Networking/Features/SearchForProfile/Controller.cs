using System.ComponentModel.DataAnnotations;
using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HexaVerticalSlice.BC.Networking.Features.SearchForProfile;

[Authorize]
[ApiController]
[Route("networking/v1/profiles")]
[Produces("application/json")]
public class ProfileController(IQueryDispatcher queryDispatcher)
    : ControllerBase
{
    [HttpGet("search/{emailAddress}")]
    [ProducesResponseType(typeof(ProfileDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> Search([Required] [FromRoute] string emailAddress)
    {
        var query = new SearchForProfileQuery(emailAddress);

        var details = await queryDispatcher.Dispatch(query);

        return Ok(details);
    }
}