﻿using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Commands;
using HexaVerticalSlice.BC.AccountManagement.Domain;
using HexaVerticalSlice.BC.AccountManagement.Features.Register.Core;
using HexaVerticalSlice.BC.AccountManagement.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace HexaVerticalSlice.BC.AccountManagement.Features.Register.Application;

internal class RegisterUserCommandHandler(
    AccountManagementDbContext dbContext,
    IUserAccountRepository userAccountRepository,
    IPasswordHasher passwordHasher,
    IJwtTokenGenerator generator
)
    : ICommandHandler<RegisterUserCommand, JwtToken>
{
    public async Task<JwtToken> Handle(RegisterUserCommand command)
    {
        await CheckEmailAddressAndPhoneNumberAreNotAlreadyUsed(command.EmailAddress);

        var passwordHash = passwordHasher.Hash(command.Password);

        var account = UserAccount.Register(command.EmailAddress, passwordHash);

        await userAccountRepository.Save(account);

        return generator.Generate(account.AccountId, command.EmailAddress);
    }

    private async Task CheckEmailAddressAndPhoneNumberAreNotAlreadyUsed(EmailAddress emailAddress)
    {
        if (await AnyUserAlreadyRegisteredWithEmail(emailAddress))
        {
            throw new EmailAddressAlreadyUsedByAnotherUserException();
        }
    }

    private Task<bool> AnyUserAlreadyRegisteredWithEmail(EmailAddress emailAddress) =>
        dbContext.Users
            .Where(x => x.EmailAddress == emailAddress)
            .AnyAsync();
}
