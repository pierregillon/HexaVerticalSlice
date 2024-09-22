﻿using HexaVerticalSlice.BC.AccountManagement.Domain.Security;
using HexaVerticalSlice.BC.AccountManagement.Features.Login.Core;
using HexaVerticalSlice.BC.AccountManagement.Features.Register.Core;
using Microsoft.AspNetCore.Identity;

namespace HexaVerticalSlice.BC.AccountManagement.Infra.Hasher;

internal class AspNetCoreIdentityPasswordHasher : IPasswordHasher, IPasswordHashVerifier
{
    private readonly PasswordHasher<AspNetCoreIdentityPasswordHasher> _passwordHasher = new();

    public PasswordHash Hash(Password password) =>
        PasswordHash.Create(_passwordHasher.HashPassword(this, password));

    public bool Verify(UnverifiedPassword password, PasswordHash passwordHash) =>
        _passwordHasher.VerifyHashedPassword(this, passwordHash, password) != PasswordVerificationResult.Failed;
}