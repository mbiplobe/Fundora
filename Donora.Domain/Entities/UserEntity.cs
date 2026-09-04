using Donora.Shared.Abstractions.Domains;

namespace Donora.Domain.Entities;

public sealed class UserEntity : AggregateRoot<Guid>
{
    public string FirstName { get; private set; } = string.Empty;

    public string? MiddleName { get; private set; }
    public string? UserName { get; private set; }

    public string LastName { get; private set; } = string.Empty;

    public string Email { get; private set; } = string.Empty;

    public string Mobile { get; private set; } = string.Empty;

    public string PasswordHash { get; private set; } = string.Empty;

    public bool IsActive { get; private set; }

    public bool IsEmailVerified { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    private UserEntity()
    {
    }

    public UserEntity(
        EntityID id,
        string firstName,
        string lastName,
        string email,
        string mobile,
        string passwordHash,
        string? middleName = null)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("First name is required.");

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Last name is required.");

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is required.");

        if (string.IsNullOrWhiteSpace(mobile))
            throw new ArgumentException("Mobile number is required.");

        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException("Password hash is required.");

        Id = Guid.NewGuid();

        FirstName = firstName.Trim();
        MiddleName = middleName?.Trim();
        LastName = lastName.Trim();

        Email = email.Trim().ToLowerInvariant();
        Mobile = mobile.Trim();
        Id = id;
        PasswordHash = passwordHash;

        IsActive = true;
        IsEmailVerified = false;

        CreatedAt = DateTime.UtcNow;
    }

    public void VerifyEmail()
    {
        IsEmailVerified = true;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Activate()
    {
        IsActive = true;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        IsActive = false;
        UpdatedAt = DateTime.UtcNow;
    }

    public void ChangePassword(string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException("Password hash is required.");

        PasswordHash = passwordHash;
        UpdatedAt = DateTime.UtcNow;
    }
}