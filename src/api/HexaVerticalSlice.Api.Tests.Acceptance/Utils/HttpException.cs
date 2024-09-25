using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace HexaVerticalSlice.Api.Tests.Acceptance.Utils;

public class HttpException(string path, ProblemDetails problemDetails)
    : Exception($"{(HttpStatusCode)problemDetails.Status!} on {path} : {problemDetails.Title ?? "No details"}")
{
    public ProblemDetails ProblemDetails { get; } = problemDetails;

    public static HttpException From(string path, HttpStatusCode statusCode)
        => new(path, new ProblemDetails { Status = (int)statusCode });

    public static Exception From(string path, ProblemDetails problemDetails)
        => new HttpException(path, problemDetails);
}