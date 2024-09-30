using System.ComponentModel.DataAnnotations;
using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;
using HexaVerticalSlice.BC.Networking.CoreDomain.Profiles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HexaVerticalSlice.BC.Networking.UseCases.ListConnections;

[Authorize]
[ApiController]
[Produces("application/json")]
public class NetworkingController(IQueryDispatcher dispatcher)
    : ControllerBase
{
    [HttpGet("networking/v1/profile/{profileId}/connections")]
    [ProducesResponseType(typeof(IReadOnlyCollection<ConnectionDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListConnections([Required] [FromRoute] Guid profileId)
    {
        var query = new ListConnectionsQuery(ProfileId.Rehydrate(profileId));

        var results = await dispatcher.Dispatch(query);

        return Ok(results);
    }
}