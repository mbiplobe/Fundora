using Donora.Shared.Abstractions.Domains;

namespace Donora.Domain.Entities;

public sealed class DonorEntity : AggregateRoot<Guid>
{

    public Guid? UserId { get; private set; }

    public string? DisplayName { get; private set; }

    public bool IsAnonymous { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public UserEntity? User { get; private set; } = new();

    public ICollection<DonationEntity> Donations { get; private set; }
        = new List<DonationEntity>();

    private DonorEntity()
    {
    }

    public DonorEntity(
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