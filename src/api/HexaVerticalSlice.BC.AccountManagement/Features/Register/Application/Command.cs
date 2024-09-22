using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Commands;
using HexaVerticalSlice.BC.AccountManagement.Domain;
using HexaVerticalSlice.BC.AccountManagement.Domain.Security;

namespace HexaVerticalSlice.BC.AccountManagement.Features.Register.Application;

public record RegisterUserCommand(EmailAddress EmailAddress, Password Password) : ICommand<JwtToken>;
