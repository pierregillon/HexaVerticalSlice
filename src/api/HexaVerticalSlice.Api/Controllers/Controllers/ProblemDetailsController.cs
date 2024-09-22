using HexaVerticalSlice.Api.BuildingBlocks.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using HexaVerticalSlice.Api.BuildingBlocks;

namespace HexaVerticalSlice.Controllers.Controllers;

public abstract class ProblemDetailsController(
    ProblemDetailsFactory factory,
    IHostEnvironment hostEnvironment
) : ControllerBase
{
    protected IActionResult BuildProblemDetails(
        Exception exception,
        int statusCode,
        string? type = null,
        IDictionary<string, object>? extensions = null
    )
    {
        var problem = CreateProblemDetails(
            statusCode,
            exception.Message,
            type ?? exception.GetType().Name.TrimEnd("Exception")
        );

        if (hostEnvironment.IsDevelopment() || hostEnvironment.EnvironmentName == "test")
        {
            problem.Extensions.Add("exception", RenderException(exception));
        }

        if (extensions is not null)
        {
            foreach (var extension in extensions)
            {
                problem.Extensions.Add(extension.Key, extension.Value);
            }
        }

        if (exception is IExceptionWithReason withReason)
        {
            problem.Extensions.Add("reason", withReason.Reason);
        }

        return MakeResult(problem);
    }

    protected IActionResult BuildProblemDetails(string errorMessage, int statusCode, string errorType)
    {
        var problemDetails = CreateProblemDetails(
            statusCode,
            errorMessage,
            errorType
        );
        return MakeResult(problemDetails);
    }

    private ProblemDetails CreateProblemDetails(int httpStatusCode, string? title, string type) =>
        factory.CreateProblemDetails(
            HttpContext,
            httpStatusCode,
            title,
            type
        );

    private ObjectResult MakeResult(ProblemDetails problem) => StatusCode(problem.Status!.Value, problem);

    private static object RenderException(Exception? e)
    {
        if (e is null)
        {
            return new { Message = "no detail available." };
        }

        return new
        {
            e.Message,
            e.Data,
            InnerException = e.InnerException != null ? RenderException(e.InnerException) : null,
            e.StackTrace,
            HResult = e.HResult.ToString("X"),
            e.Source,
            TargetSite = e.TargetSite?.ToString()
        };
    }
}
