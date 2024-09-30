using HexaVerticalSlice.BC.Feeds.UseCases.GetFeed.Ports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HexaVerticalSlice.BC.Feeds.UseCases.GetFeed.Adapters;

[Authorize]
[ApiController]
[Route("feed-computation/v1/feed")]
[Produces("application/json")]
public class FeedComputationController(IGetFeedUseCase useCase)
    : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(FeedDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetFeed()
    {
        var feed = await useCase.Execute();

        return Ok(feed);
    }
}