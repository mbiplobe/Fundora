using System.Text.RegularExpressions;

public sealed record Email
{
    public string Value { get; }

    private static readonly Regex EmailRegex =
        new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new UserInvalidException("Email is required.");
        }

        value = value.Trim().ToLowerInvariant();

        if (!EmailRegex.IsMatch(value))
        {
            throw new UserInvalidException("Invalid email format.");
        }

        Value = value;
    }

    public static implicit operator string(Email email)
        => email?.Value ?? string.Empty;

    public static implicit operator Email(string email)
        => new(email);

    public override string ToString()
        => Value;
}