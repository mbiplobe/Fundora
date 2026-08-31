namespace Donora.Infrastructure.EF.Models;

internal class DonationReadModel : BaseModel
{
    public Guid CampaignId { get; set; }

    public string? CampaignTitle { get; set; }

    public Guid? DonorId { get; set; }

    public string? DonorName { get; set; }

    public decimal Amount { get; set; }

    public string Currency { get; set; } = "BDT";

    public bool IsAnonymous { get; set; }

    public string? Message { get; set; }

    public string Status { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}