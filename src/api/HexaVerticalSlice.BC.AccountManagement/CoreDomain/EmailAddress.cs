using System.Text.RegularExpressions;

namespace HexaVerticalSlice.BC.AccountManagement.CoreDomain;

public record EmailAddress
{
    private static readonly Regex EmailAddressPattern = new(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,10})+)$");

    private readonly string _value;

    private EmailAddress(string value) => _value = value;

    public static EmailAddress Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(value));
        }

        if (!EmailAddressPattern.IsMatch(value))
        {
            throw new BadEmailAddressFormatException();
        }

        return new EmailAddress(value.ToLower());
    }

    public static EmailAddress Rehydrate(string value) => new(value);

    public static implicit operator string(EmailAddress emailAddress) => emailAddress._value;

    public override string ToString() => _value;
}
