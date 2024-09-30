using System.ComponentModel.DataAnnotations;
using HexaVerticalSlice.BC.FeedComputation.UseCases.GetFeed.Ports;
using HexaVerticalSlice.BC.FeedComputation.UseCases.PublishPost.Ports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HexaVerticalSlice.BC.FeedComputation.UseCases.PublishPost.Adapters;

[Authorize]
[ApiController]
[Produces("application/json")]
public class FeedComputationController(IPublishPostUseCase useCase)
    : ControllerBase
{
    [HttpPost("feed-computation/v1/posts/")]
    [ProducesResponseType(typeof(FeedDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> SendPost([Required] [FromBody] SendPostControllerBody body)
    {
        await useCase.PublishPost(body.Title, body.Content);

        return Ok();
    }
}