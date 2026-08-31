using Donora.Domain.Enums;
using Donora.Shared.Abstractions.Domains;

namespace Donora.Domain.Entities;

public sealed class DonationTransaction : AggregateRoot<Guid>
{

    public Guid DonationId { get; private set; }

    public Donation Donation { get; private set; } = null!;

    public string TransactionId { get; private set; } = string.Empty;

    public string PaymentProvider { get; private set; } = string.Empty;

    public string? PaymentMethod { get; private set; }

    public decimal Amount { get; private set; }

    public string Currency { get; private set; } = "BDT";

    public PaymentStatus Status { get; private set; }

    public string? GatewayResponse { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? CompletedAt { get; private set; }

    private DonationTransaction()
    {
    }

    public DonationTransaction(
        Guid donationId,
        string transactionId,
        string paymentProvider,
        decimal amount,
        string? paymentMethod = null)
    {
        Id = Guid.NewGuid();

        DonationId = donationId;
        TransactionId = transactionId;
        PaymentProvider = paymentProvider;
        PaymentMethod = paymentMethod;

        Amount = amount;
        Currency = "BDT";

        Status = PaymentStatus.Pending;

        CreatedAt = DateTime.UtcNow;
    }

    public void Complete(string? gatewayResponse = null)
    {
        Status = PaymentStatus.Completed;
        GatewayResponse = gatewayResponse;
        CompletedAt = DateTime.UtcNow;
    }

    public void Fail(string? gatewayResponse = null)
    {
        Status = PaymentStatus.Failed;
        GatewayResponse = gatewayResponse;
    }
}