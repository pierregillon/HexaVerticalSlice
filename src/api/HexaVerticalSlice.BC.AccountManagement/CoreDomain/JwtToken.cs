namespace HexaVerticalSlice.BC.AccountManagement.CoreDomain;

public record JwtToken(string Token, DateTime ExpireAt);
