using HexaVerticalSlice.BC.AccountManagement.CoreDomain.Security;
using HexaVerticalSlice.BC.AccountManagement.UseCases.Register.Ports;
using Microsoft.AspNetCore.Identity;

namespace HexaVerticalSlice.BC.AccountManagement.UseCases.Register.Adapters;

internal class AspNetCoreIdentityPasswordHasher : IPasswordHasher
{
    private readonly PasswordHasher<AspNetCoreIdentityPasswordHasher> _passwordHasher = new();

    public PasswordHash Hash(Password password) =>
        PasswordHash.Create(_passwordHasher.HashPassword(this, password));
}