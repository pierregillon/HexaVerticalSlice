using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Commands;
using HexaVerticalSlice.BC.AccountManagement.CoreDomain;
using HexaVerticalSlice.BC.AccountManagement.CoreDomain.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HexaVerticalSlice.BC.AccountManagement.UseCases.Register.Adapters;

[ApiController]
[Route("account-management/v1/users")]
[Produces("application/json")]
public class AccountManagementController(ICommandDispatcher commandDispatcher)
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