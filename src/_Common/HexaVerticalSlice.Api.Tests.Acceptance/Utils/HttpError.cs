﻿using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace HexaVerticalSlice.Api.Tests.Acceptance.Utils;

public class HttpError(HttpException exception)
{
    public ProblemDetails ProblemDetails { get; } = exception.ProblemDetails;
    public Exception InnerException { get; } = exception;

    public HttpStatusCode HttpStatusCode =>
        (HttpStatusCode)(ProblemDetails.Status ?? throw new InvalidOperationException("No status"));
}