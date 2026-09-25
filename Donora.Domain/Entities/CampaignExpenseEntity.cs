using Donora.Shared.Abstractions.Domains;

namespace Donora.Domain.Entities;

public sealed class CampaignExpenseEntity : AggregateRoot<Guid>
{

    public Guid CampaignId { get; private set; }

    public Campaign Campaign { get; private set; } = null!;

    public string Title { get; private set; } = string.Empty;

    public string? Description { get; private set; }

    public decimal Amount { get; private set; }

    public DateTime ExpenseDate { get; private set; }

    public string? ReceiptUrl { get; private set; }

    public DateTime CreatedAt { get; private set; }

    private CampaignExpenseEntity()
    {
    }

    public CampaignExpenseEntity(
        Guid campaignId,
        string title,
        decimal amount,
        DateTime expenseDate)
    {
        Id = Guid.NewGuid();

        CampaignId = campaignId;
        Title = title;
        Amount = amount;
        ExpenseDate = expenseDate;

        CreatedAt = DateTime.UtcNow;
    }
}