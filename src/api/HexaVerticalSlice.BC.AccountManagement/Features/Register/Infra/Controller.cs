using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Commands;
using HexaVerticalSlice.BC.AccountManagement.Domain;
using HexaVerticalSlice.BC.AccountManagement.Domain.Security;
using HexaVerticalSlice.BC.AccountManagement.Features.Register.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HexaVerticalSlice.BC.AccountManagement.Features.Register.Infra;

[ApiController]
[Route("account-management/v1/users")]
[Produces("application/json")]
public class RegisterUserController(ICommandDispatcher commandDispatcher)
    : ControllerBase
{
    /// <summary>
    ///     Register a new user with Email, Phone number and Password.
    /// </summary>
    /// <param name="body"></param>
    /// <returns>Returns a bearer token to access authorized routes</returns>
    [HttpPost("register")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(JwtToken), StatusCodes.Status200OK)]
    public async Task<IActionResult> Register([FromBody] RegisterUserControllerBody body)
    {
        var command = new RegisterUserCommand(
            EmailAddress.Create(body.Email),
            Password.Create(body.Password)
        );
        
        var token = await commandDispatcher.Dispatch(command);

        return Ok(token);
    }
    
    public record RegisterUserControllerBody(string Email, string Password);

}
