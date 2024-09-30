namespace HexaVerticalSlice.BC.AccountManagement.UseCases.Register;

public class EmailAddressAlreadyUsedByAnotherUserException()
    : Exception("The provided email address is already used by another user.");