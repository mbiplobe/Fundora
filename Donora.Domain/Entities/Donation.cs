using Donora.Domain.Enums;
using Donora.Shared.Abstractions.Domains;

namespace Donora.Domain.Entities;

public sealed class Donation : AggregateRoot<Guid>
{

    public Guid CampaignId { get; set; }

    public Guid? DonorId { get; set; }

    public decimal Amount { get; set; }

    public string Currency { get; set; } = "BDT";

    public bool IsAnonymous { get; set; }

    public string? Message { get; set; }

    
    public string? PaymentMethod { get; set; }


    public string? Message { get; set; }

    public DonationStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }

    // Navigation Properties
    public Campaign Campaign { get; set; } = null!;

    public Donor? Donor { get; set; }
}