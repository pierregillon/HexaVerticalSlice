using System.Net;
using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;
using HexaVerticalSlice.BC.AccountManagement.UseCases.AccountExists;
using HexaVerticalSlice.Configuration.Authentication.Bearer;

namespace HexaVerticalSlice.Configuration.Controllers;

public class ValidateUserExistenceMiddleware(IQueryDispatcher queryDispatcher) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.TryGetAuthenticatedUserId(out var userId))
        {
            if (!await queryDispatcher.Dispatch(new UserAccountExistsQuery(userId)))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }
        }

        await next(context);
    }
}