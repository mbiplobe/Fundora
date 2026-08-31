using System.Text.RegularExpressions;

public sealed record ClassName
{
    public string Value { get; }

    private static readonly Regex ClassRegex =
        new(@"^[A-Za-z0-9\s\-]{1,50}$", RegexOptions.Compiled);

    public ClassName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ClassInvalidException("Class name is required.");
        }

        value = value.Trim();

        if (!ClassRegex.IsMatch(value))
        {
            throw new ClassInvalidException("Invalid class name format.");
        }

        Value = value;
    }

    public static implicit operator string(ClassName className)
        => className?.Value ?? string.Empty;

    public static implicit operator ClassName(string className)
        => new(className);

    public override string ToString()
        => Value;
}
                
