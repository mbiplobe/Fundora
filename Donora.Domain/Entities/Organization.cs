using Donora.Shared.Abstractions.Domains;

namespace Donora.Domain.Entities;

public sealed class Organization : AggregateRoot<Guid>
{
    public string Name { get; private set; } = string.Empty;

    public string Slug { get; private set; } = string.Empty;

    public string? Description { get; private set; }

    public string? Email { get; private set; }

    public string? Phone { get; private set; }

    public string? Address { get; private set; }

    public string? Website { get; private set; }

    public string? LogoUrl { get; private set; }

    public Guid? OwnerUserId { get; private set; }

    public bool IsVerified { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public ICollection<Campaign> Campaigns { get; private set; }
        = new List<Campaign>();

    public ICollection<Beneficiary> Beneficiaries { get; private set; }
        = new List<Beneficiary>();

    private Organization()
    {
    }

    public Organization(
        string name,
        string slug,
        Guid? ownerUserId = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Organization name is required.");

        if (string.IsNullOrWhiteSpace(slug))
            throw new ArgumentException("Organization slug is required.");

        Id = Guid.NewGuid();
        Name = name;
        Slug = slug;
        OwnerUserId = ownerUserId;

        IsVerified = false;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }
}