using System.ComponentModel.DataAnnotations;
using HexaVerticalSlice.BC.FeedComputation.UseCases.GetPostDetails.Ports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HexaVerticalSlice.BC.FeedComputation.UseCases.GetPostDetails.Adapters;

[Authorize]
[ApiController]
[Produces("application/json")]
public class FeedComputationController(IGetPostDetailsUseCase useCase)
    : ControllerBase
{
    [HttpGet("feed-computation/v1/posts/{postId}")]
    [ProducesResponseType(typeof(PostDetailsDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDetails([FromRoute] [Required] Guid postId)
    {
        var results = await useCase.GetDetails(postId);

        return Ok(results);
    }
}