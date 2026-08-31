namespace Donora.Infrastructure.EF.Models;

internal class DonationTransactionReadModel : BaseModel
{
    public Guid DonationId { get; set; }

    public string? TransactionId { get; set; }

    public string? PaymentProvider { get; set; }

    public string? PaymentMethod { get; set; }

    public decimal Amount { get; set; }

    public string Currency { get; set; } = "BDT";

    public string Status { get; set; } = string.Empty;

    public DateTime? CompletedAt { get; set; }
}