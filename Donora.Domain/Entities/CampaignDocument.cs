using Donora.Shared.Abstractions.Domains;

namespace Donora.Domain.Entities;

public sealed class CampaignDocument : AggregateRoot<Guid>
{

    public Guid CampaignId { get; private set; }

    public Campaign Campaign { get; private set; } = null!;

    public string DocumentType { get; private set; } = string.Empty;

    public string FileName { get; private set; } = string.Empty;

    public string FileUrl { get; private set; } = string.Empty;

    public DateTime UploadedAt { get; private set; }

    private CampaignDocument()
    {
    }

    public CampaignDocument(
        Guid campaignId,
        string documentType,
        string fileName,
        string fileUrl)
    {
        Id = Guid.NewGuid();

        CampaignId = campaignId;
        DocumentType = documentType;
        FileName = fileName;
        FileUrl = fileUrl;

        UploadedAt = DateTime.UtcNow;
    }
}