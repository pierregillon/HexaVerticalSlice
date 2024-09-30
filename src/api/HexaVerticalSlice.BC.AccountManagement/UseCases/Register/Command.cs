using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Commands;
using HexaVerticalSlice.BC.AccountManagement.CoreDomain;
using HexaVerticalSlice.BC.AccountManagement.CoreDomain.Security;

namespace HexaVerticalSlice.BC.AccountManagement.UseCases.Register;

public record RegisterUserCommand(EmailAddress EmailAddress, Password Password) : ICommand<JwtToken>;
