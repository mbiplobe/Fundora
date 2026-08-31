namespace Donora.Infrastructure.EF.Models;

internal class CampaignDocumentReadModel : BaseModel
{
    public Guid CampaignId { get; set; }

    public string? DocumentType { get; set; }

    public string? FileName { get; set; }

    public string? FileUrl { get; set; }

    public DateTime UploadedAt { get; set; }
}