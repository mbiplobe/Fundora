using Donora.Shared.Abstractions.Domains;

namespace Donora.Domain.Entities;

public sealed class DonationReceipt : AggregateRoot<Guid>
{
    public Guid DonationId { get; private set; }

    public Donation Donation { get; private set; } = null!;

    public string ReceiptNumber { get; private set; } = string.Empty;

    public string? ReceiptUrl { get; private set; }

    public DateTime IssuedAt { get; private set; }

    private DonationReceipt()
    {
    }

    public DonationReceipt(
        Guid donationId,
        string receiptNumber,
        string? receiptUrl = null)
    {
        Id = Guid.NewGuid();

        DonationId = donationId;
        ReceiptNumber = receiptNumber;
        ReceiptUrl = receiptUrl;

        IssuedAt = DateTime.UtcNow;
    }
}
