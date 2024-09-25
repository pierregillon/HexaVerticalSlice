using HexaVerticalSlice.Api.BuildingBlocks.Tenant;
using HexaVerticalSlice.Configuration.Authentication.Bearer;

namespace HexaVerticalSlice.Configuration.Controllers;

public class InitializeUserContextMiddleware(ICurrentTenant tenant) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.TryGetAuthenticatedUserId(out var userId))
        {
            tenant.DefineUserId(new UserTenantId(userId));
        }

        await next(context);
    }
}