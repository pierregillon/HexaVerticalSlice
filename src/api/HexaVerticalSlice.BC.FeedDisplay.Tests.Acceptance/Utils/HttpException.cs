﻿using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace HexaVerticalSlice.BC.FeedDisplay.Tests.Acceptance.Utils;

public class HttpException(string path, ProblemDetails problemDetails)
    : Exception($"{(HttpStatusCode)problemDetails.Status!} on {path} : {problemDetails.Title ?? "No details"}")
{
    public ProblemDetails ProblemDetails { get; } = problemDetails;

    public static Exception From(string path, HttpStatusCode statusCode) 
        => new HttpException(path, new ProblemDetails {Status = (int)statusCode });

    public static Exception From(string path, ProblemDetails problemDetails) 
        => new HttpException(path, problemDetails);
}