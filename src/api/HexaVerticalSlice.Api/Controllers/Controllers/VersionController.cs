using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace HexaVerticalSlice.Controllers.Controllers;

[ApiController]
[Route("v1/version")]
public class VersionController : ControllerBase
{
    /// <summary>
    /// Get the assembly version of the running api.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public string? Get() => Assembly.GetEntryAssembly()?.GetName().Version?.ToString();
}
