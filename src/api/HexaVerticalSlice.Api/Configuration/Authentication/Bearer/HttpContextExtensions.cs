using System.Security.Claims;
using HexaVerticalSlice.BC.AccountManagement.Domain;

namespace HexaVerticalSlice.Configuration.Authentication.Bearer;

public static class HttpContextExtensions
{
    public static bool TryGetAuthenticatedUserId(this HttpContext context, out UserAccountId userAccountId)
    {
        var claim = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
        if (claim == null)
        {
            userAccountId = null!;
            return false;
        }

        userAccountId = new UserAccountId(Guid.Parse(claim.Value));
        return true;
    }
}