namespace HexaVerticalSlice.BC.AccountManagement.CoreDomain.Security;

public record Password
{
    private readonly string _value;

    private Password(string value) => _value = value;

    public static implicit operator string(Password password) => password._value;

    public static Password Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(value));
        }

        if (value.Length < 4)
        {
            throw new TooWeakPasswordException();
        }

        return new Password(value);
    }
}
