namespace SchoolManagement.Domain.ValueObjects;

public sealed class UserType : IEquatable<UserType>
{
    public string Value { get; }

    private UserType(string value)
    {
        Value = value;
    }

    public static readonly UserType Admin = new("Admin");
    public static readonly UserType Teacher = new("Teacher");
    public static readonly UserType Student = new("Student");

    public static UserType Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("User type is required.");

        return value.Trim().ToLower() switch
        {
            "admin" => Admin,
            "teacher" => Teacher,
            "student" => Student,
            _ => throw new ArgumentException("Invalid user type.")
        };
    }

    public override string ToString()
        => Value;

    public override bool Equals(object? obj)
        => Equals(obj as UserType);

    public bool Equals(UserType? other)
        => other is not null && Value == other.Value;

    public override int GetHashCode()
        => Value.GetHashCode();

    public static implicit operator string(UserType userType)
        => userType.Value;

    public static implicit operator UserType(string value)
        => Create(value);
}