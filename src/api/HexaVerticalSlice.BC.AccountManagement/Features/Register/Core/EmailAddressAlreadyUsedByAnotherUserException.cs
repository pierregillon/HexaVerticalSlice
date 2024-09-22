namespace HexaVerticalSlice.BC.AccountManagement.Features.Register.Core;

public class EmailAddressAlreadyUsedByAnotherUserException()
    : Exception("The provided email address is already used by another user.");
