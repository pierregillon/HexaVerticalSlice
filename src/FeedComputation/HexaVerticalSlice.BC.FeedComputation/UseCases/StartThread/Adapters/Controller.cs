using System.ComponentModel.DataAnnotations;
using HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread.CoreDomain;
using HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread.Ports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread.Adapters;

[Authorize]
[ApiController]
[Produces("application/json")]
public class FeedComputationController(IStartThreadUseCase useCase)
    : ControllerBase
{
    [HttpPost("feed-computation/v1/posts/{postId}/comments/")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> SendPost([Required] [FromBody] StartThreadBody body, Guid postId)
    {
        await useCase.StartThread(
            ThreadId.Rehydrate(body.Id),
            new CommentDescription(body.Comment),
            PostId.Rehydrate(postId)
        );

        return Ok();
    }
}