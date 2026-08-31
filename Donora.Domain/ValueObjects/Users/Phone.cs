using System.Text.RegularExpressions;

public sealed record Phone
{
    public string Value { get; }

    private static readonly Regex PhoneRegex =
        new(@"^01[3-9]\d{8}$",
            RegexOptions.Compiled);

    public Phone(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new UserInvalidException("Phone number is required.");
        }

        value = value.Trim();

        if (!PhoneRegex.IsMatch(value))
        {
            throw new UserInvalidException(
                "Phone number must be a valid 11-digit Bangladesh number.");
        }

        Value = value;
    }

    public static implicit operator string(Phone phone)
        => phone?.Value ?? string.Empty;

    public static implicit operator Phone(string phone)
        => new(phone);

    public override string ToString()
        => Value;
}