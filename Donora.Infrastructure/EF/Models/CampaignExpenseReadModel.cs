namespace Donora.Infrastructure.EF.Models;

internal class CampaignExpenseReadModel : BaseModel
{
    public Guid CampaignId { get; set; }

    public string? CampaignTitle { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public decimal Amount { get; set; }

    public DateTime ExpenseDate { get; set; }

    public string? ReceiptUrl { get; set; }
}