using Donora.Shared.Abstractions.Domains;

namespace Donora.Domain.Entities;

public sealed class CampaignBeneficiaryEntity : AggregateRoot<Guid>
{
    public Guid CampaignId { get; private set; }

    public Campaign Campaign { get; private set; } = null!;

    public Guid BeneficiaryId { get; private set; }

    public Beneficiary Beneficiary { get; private set; } = null!;

    private CampaignBeneficiaryEntity()
    {
    }

    public CampaignBeneficiaryEntity(
        Guid campaignId,
        Guid beneficiaryId)
    {
        CampaignId = campaignId;
        BeneficiaryId = beneficiaryId;
    }
}