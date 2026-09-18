using Donora.Domain.Consts;
using Donora.Shared.Abstractions.Domains;


namespace Donora.Domain.Entities;

public sealed class Beneficiary : AggregateRoot<Guid>
{

    public Guid OrganizationId { get; private set; }

    public Organization Organization { get; private set; } = null!;

    public string Name { get; private set; } = string.Empty;

    public string? Description { get; private set; }

    public string? PhoneNumber { get; private set; }

    public string? Address { get; private set; }

    public VerificationStatus VerificationStatus { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public ICollection<CampaignBeneficiary> CampaignBeneficiaries { get; private set; }
        = new List<CampaignBeneficiary>();

    private Beneficiary()
    {
    }

    public Beneficiary(
        Guid organizationId,
        string name,
        string? description = null)
    {
        Id = Guid.NewGuid();

        OrganizationId = organizationId;
        Name = name;
        Description = description;

        VerificationStatus = VerificationStatus.Pending;

        CreatedAt = DateTime.UtcNow;
    }
}