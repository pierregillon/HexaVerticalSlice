using System.ComponentModel.DataAnnotations;
using HexaVerticalSlice.BC.Feeds.UseCases.GetFeed;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HexaVerticalSlice.BC.Feeds.UseCases.SendPost.Adapters;

[Authorize]
[ApiController]
[Produces("application/json")]
public class FeedComputationController(SendPostUseCase useCase)
    : ControllerBase
{
    [HttpPost("feed-computation/v1/posts/")]
    [ProducesResponseType(typeof(FeedDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> SendPost([Required] [FromBody] SendPostControllerBody body)
    {
        await useCase.SendPost(body.Title, body.Content);

        return Ok();
    }
}