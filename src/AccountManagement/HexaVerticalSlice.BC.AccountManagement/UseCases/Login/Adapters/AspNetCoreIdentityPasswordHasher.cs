using HexaVerticalSlice.BC.AccountManagement.CoreDomain.Security;
using HexaVerticalSlice.BC.AccountManagement.UseCases.Login.Ports;
using Microsoft.AspNetCore.Identity;

namespace HexaVerticalSlice.BC.AccountManagement.UseCases.Login.Adapters;

internal class AspNetCoreIdentityPasswordHashVerifier : IPasswordHashVerifier
{
    private readonly PasswordHasher<AspNetCoreIdentityPasswordHashVerifier> _passwordHasher = new();

    public bool Verify(UnverifiedPassword password, PasswordHash passwordHash) =>
        _passwordHasher.VerifyHashedPassword(this, passwordHash, password) != PasswordVerificationResult.Failed;
}