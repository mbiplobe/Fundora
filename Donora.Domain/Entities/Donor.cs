using Donora.Shared.Abstractions.Domains;

namespace Donora.Domain.Entities;

public sealed class Donor : AggregateRoot<Guid>
{

    public Guid? UserId { get; private set; }

    public string? DisplayName { get; private set; }

    public bool IsAnonymous { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public ICollection<Donation> Donations { get; private set; }
        = new List<Donation>();

    private Donor()
    {
    }

    public Donor(
        Guid? userId,
        string? displayName,
        bool isAnonymous = false)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        DisplayName = displayName;
        IsAnonymous = isAnonymous;
        CreatedAt = DateTime.UtcNow;
    }
}