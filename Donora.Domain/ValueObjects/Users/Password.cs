using System.Text.RegularExpressions;

public sealed record Password
{
    public string Value { get; }

    // Criteria: Min 8 chars, at least one uppercase, one lowercase, one number, and one special char
    private static readonly Regex PasswordRegex = 
        new(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", 
            RegexOptions.Compiled);

    public Password(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new UserInvalidException("Password is required.");
        }

        if (!PasswordRegex.IsMatch(value))
        {
            throw new UserInvalidException(
                "Password must be at least 8 characters long and include uppercase, lowercase, a number, and a special character.");
        }

        Value = value;
    }

    public bool Verify(string password)
    {
        return Value == password;
    }

    public static implicit operator string(Password password)
        => password?.Value ?? string.Empty;

    public static implicit operator Password(string password)
        => new(password);

    public override string ToString() => "********"; 
}