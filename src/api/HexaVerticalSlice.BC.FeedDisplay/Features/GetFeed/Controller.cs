using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;
using Microsoft.AspNetCore.Mvc;

namespace HexaVerticalSlice.BC.FeedDisplay.Features.GetFeed;

[ApiController]
[Route("feed-display/v1/feed")]
[Produces("application/json")]
public class FeedController(IQueryDispatcher queryDispatcher)
    : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(FeedDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetFeed()
    {
        var query = new GetFeedQuery();
        
        var token = await queryDispatcher.Dispatch(query);

        return Ok(token);
    }
}