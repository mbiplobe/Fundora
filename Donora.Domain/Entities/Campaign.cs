
using Donora.Domain.Enums;
using Donora.Shared.Abstractions.Domains;

namespace Donora.Domain.Entities;

public sealed class Campaign : AggregateRoot<Guid>
{

    public Guid OrganizationId { get; private set; }

    public Organization Organization { get; private set; } = null!;

    public string Title { get; private set; } = string.Empty;

    public string Slug { get; private set; } = string.Empty;

    public string? Description { get; private set; }

    public decimal TargetAmount { get; private set; }

    public decimal CollectedAmount { get; private set; }

    public string Currency { get; private set; } = "BDT";

    public DateTime StartDate { get; private set; }

    public DateTime? EndDate { get; private set; }

    public CampaignStatus Status { get; private set; }

    public string? CoverImageUrl { get; private set; }

    public bool IsFeatured { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public ICollection<Donation> Donations { get; private set; }
        = new List<Donation>();

    public ICollection<CampaignExpense> Expenses { get; private set; }
        = new List<CampaignExpense>();

    public ICollection<CampaignDocument> Documents { get; private set; }
        = new List<CampaignDocument>();

    public ICollection<CampaignBeneficiary> CampaignBeneficiaries { get; private set; }
        = new List<CampaignBeneficiary>();

    private Campaign()
    {
    }

    public Campaign(
        Guid organizationId,
        string title,
        string slug,
        decimal targetAmount,
        DateTime startDate,
        DateTime? endDate = null,
        string? description = null)
    {
        if (organizationId == Guid.Empty)
            throw new ArgumentException("Organization is required.");

        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Campaign title is required.");

        if (string.IsNullOrWhiteSpace(slug))
            throw new ArgumentException("Campaign slug is required.");

        if (targetAmount <= 0)
            throw new ArgumentException("Target amount must be greater than zero.");

        Id = Guid.NewGuid();

        OrganizationId = organizationId;
        Title = title;
        Slug = slug;
        Description = description;
        TargetAmount = targetAmount;

        StartDate = startDate;
        EndDate = endDate;

        Currency = "BDT";
        Status = CampaignStatus.Draft;

        CollectedAmount = 0;
        IsFeatured = false;

        CreatedAt = DateTime.UtcNow;
    }

    public void Publish()
    {
        Status = CampaignStatus.Published;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Pause()
    {
        Status = CampaignStatus.Paused;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Complete()
    {
        Status = CampaignStatus.Completed;
        UpdatedAt = DateTime.UtcNow;
    }

    public void AddDonation(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Donation amount must be greater than zero.");

        CollectedAmount += amount;

        if (CollectedAmount >= TargetAmount)
        {
            Status = CampaignStatus.Completed;
        }

        UpdatedAt = DateTime.UtcNow;
    }
}