namespace Donora.Infrastructure.EF.Models;

internal class CampaignReadModel : BaseModel
{
    public string? Title { get; set; }

    public string? OrganizationName { get; set; }

    public decimal TargetAmount { get; set; }

    public decimal CollectedAmount { get; set; }

    public string Currency { get; set; } = "BDT";

    public int DonorCount { get; set; }

    public string Status { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}