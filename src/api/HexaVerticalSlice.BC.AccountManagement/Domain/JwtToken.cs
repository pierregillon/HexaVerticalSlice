namespace HexaVerticalSlice.BC.AccountManagement.Domain;

public record JwtToken(string Token, DateTime ExpireAt);
