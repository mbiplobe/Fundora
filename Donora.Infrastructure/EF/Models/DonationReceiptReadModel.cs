namespace Donora.Infrastructure.EF.Models;

internal class DonationReceiptReadModel : BaseModel
{
    public Guid DonationId { get; set; }

    public string? ReceiptNumber { get; set; }

    public string? ReceiptUrl { get; set; }

    public DateTime IssuedAt { get; set; }
}