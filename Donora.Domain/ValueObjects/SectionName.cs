using System.Text.RegularExpressions;

public sealed record SectionName
{
    public string Value { get; }

    private static readonly Regex SectionRegex =
        new(@"^[A-Za-z0-9\s\-]{1,50}$", RegexOptions.Compiled);

    public SectionName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new SectionInvalidException("Section name is required.");
        }

        value = value.Trim();

        if (!SectionRegex.IsMatch(value))
        {
            throw new SectionInvalidException("Invalid section name format.");
        }

        Value = value;
    }

    public static implicit operator string(SectionName sectionName)
        => sectionName?.Value ?? string.Empty;

    public static implicit operator SectionName(string sectionName)
        => new(sectionName);

    public override string ToString()
        => Value;
}
                
