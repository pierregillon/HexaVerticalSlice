using HexaVerticalSlice.BC.FeedComputation.UseCases.ListPosts.Ports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HexaVerticalSlice.BC.FeedComputation.UseCases.ListPosts.Adapters;

[Authorize]
[ApiController]
[Produces("application/json")]
public class FeedComputationController(IListPostsUseCase useCase)
    : ControllerBase
{
    [HttpGet("feed-computation/v1/posts/")]
    [ProducesResponseType(typeof(IReadOnlyCollection<PostListItemDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListPosts()
    {
        var results = await useCase.ListPosts();

        return Ok(results);
    }
}