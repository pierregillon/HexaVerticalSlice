namespace HexaVerticalSlice.BC.AccountManagement.CoreDomain.Security;

public record PasswordHash
{
    private readonly string _value;

    private PasswordHash(string value) => _value = value;

    public static PasswordHash Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(value));
        }

        return new PasswordHash(value);
    }

    public static implicit operator string(PasswordHash password) => password._value;
}