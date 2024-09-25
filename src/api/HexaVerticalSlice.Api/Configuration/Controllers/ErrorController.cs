using System.Diagnostics;
using HexaVerticalSlice.Api.BuildingBlocks.Aggregates;
using HexaVerticalSlice.Api.BuildingBlocks.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace HexaVerticalSlice.Configuration.Controllers;

[ApiController]
[AllowAnonymous]
public class ErrorController(ProblemDetailsFactory factory, IHostEnvironment hostEnvironment)
    : ProblemDetailsController(factory, hostEnvironment)
{
    [Route("internal/error")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult Error()
    {
        var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

        AdjustActivityMetadata(context);

        return Handle(context?.Error);
    }

    private static void AdjustActivityMetadata(IExceptionHandlerFeature? context)
    {
        if (Activity.Current is null)
        {
            return;
        }

        var exception = context?.Error;

        // This allow to visualize correctly route in error in ApplicationInsight.
        // Else it is under route Internal/Error which is generic.
        Activity.Current.DisplayName = context?.Path ?? Activity.Current.DisplayName;
        Activity.Current.SetTag("http.route", context?.Path);
        Activity.Current.SetStatus(ActivityStatusCode.Error, exception?.Message);
    }

    private IActionResult Handle(Exception? exception)
    {
        if (exception is null)
        {
            return HandledUnspecifiedError();
        }

        return exception switch
        {
            UnauthorizedException => BuildProblemDetails(exception, StatusCodes.Status401Unauthorized),
            ArgumentException => BuildProblemDetails(exception, StatusCodes.Status400BadRequest),
            BadFormatException => BuildProblemDetails(exception, StatusCodes.Status400BadRequest),
            ConflictException => BuildProblemDetails(exception, StatusCodes.Status409Conflict),
            ForbiddenException => BuildProblemDetails(exception, StatusCodes.Status403Forbidden),
            NotFoundException => BuildProblemDetails(exception, StatusCodes.Status404NotFound),
            AggregateNotFoundException => BuildProblemDetails(exception, StatusCodes.Status404NotFound),
            _ => BuildDefaultProblemDetails(exception)
        };
    }

    private IActionResult BuildDefaultProblemDetails(Exception exception)
        => BuildProblemDetails(
            exception,
            StatusCodes.Status500InternalServerError,
            "UnexpectedException"
        );

    private IActionResult HandledUnspecifiedError()
        => BuildProblemDetails(
            "no detail available.",
            StatusCodes.Status500InternalServerError,
            "MissingException"
        );
}