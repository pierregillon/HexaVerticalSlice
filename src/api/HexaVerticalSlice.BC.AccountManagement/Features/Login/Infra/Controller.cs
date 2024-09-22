using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;
using HexaVerticalSlice.BC.AccountManagement.Domain;
using HexaVerticalSlice.BC.AccountManagement.Domain.Security;
using HexaVerticalSlice.BC.AccountManagement.Features.Login.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HexaVerticalSlice.BC.AccountManagement.Features.Login.Infra;

[ApiController]
[Route("account-management/v1/users")]
[Produces("application/json")]
public class UserController(IQueryDispatcher queryDispatcher)
    : ControllerBase
{
    [HttpPost("login")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(JwtToken), StatusCodes.Status200OK)]
    public async Task<IActionResult> LogIn([FromBody] ControllerModel controllerModel)
    {
        var query = new LogInUserQuery(
            EmailAddress.Create(controllerModel.Email), 
            new UnverifiedPassword(controllerModel.Password)
        );
        
        var token = await queryDispatcher.Dispatch(query);

        return Ok(token);
    }
}
