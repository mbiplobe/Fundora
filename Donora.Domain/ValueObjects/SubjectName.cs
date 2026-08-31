using System.Text.RegularExpressions;

public sealed record SubjectName
{
    public string Value { get; }

    private static readonly Regex SubjectRegex =
        new(@"^[A-Za-z0-9\s\-]{1,50}$", RegexOptions.Compiled);

    public SubjectName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new SubjectInvalidException("Subject name is required.");
        }

        value = value.Trim();

        if (!SubjectRegex.IsMatch(value))
        {
            throw new SubjectInvalidException("Invalid subject name format.");
        }

        Value = value;
    }

    public static implicit operator string(SubjectName subjectName)
        => subjectName?.Value ?? string.Empty;

    public static implicit operator SubjectName(string subjectName)
        => new(subjectName);

    public override string ToString()
        => Value;
}
