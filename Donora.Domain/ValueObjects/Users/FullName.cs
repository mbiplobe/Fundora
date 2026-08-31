

public sealed record FullName
{
    public string FirstName { get; }
    public string? MiddleName { get; }
    public string LastName { get; }

    public FullName(
        string firstName,
        string? middleName,
        string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new UserInvalidException(
                "First name is required.");

        if (string.IsNullOrWhiteSpace(lastName))
            throw new UserInvalidException(
                "Last name is required.");

        FirstName = firstName.Trim();
        MiddleName = string.IsNullOrWhiteSpace(middleName)
            ? null
            : middleName.Trim();

        LastName = lastName.Trim();
    }

    public override string ToString()
    {
        return string.Join(" ",
            new[]
            {
                FirstName,
                MiddleName,
                LastName
            }
            .Where(x => !string.IsNullOrWhiteSpace(x)));
    }
}