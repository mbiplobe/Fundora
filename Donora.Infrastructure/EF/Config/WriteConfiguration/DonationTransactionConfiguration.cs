using Donora.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donora.Infrastructure.EF.Configurations;

internal sealed class DonationTransactionConfiguration
    : IEntityTypeConfiguration<DonationTransaction>
{
    public void Configure(EntityTypeBuilder<DonationTransaction> builder)
    {
        builder.ToTable("donation_transactions");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.DonationId)
            .IsRequired();

        builder.Property(x => x.TransactionId)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.PaymentProvider)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.PaymentMethod)
            .HasMaxLength(50);

        builder.Property(x => x.Amount)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.Currency)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(x => x.Status)
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.GatewayResponse)
            .HasMaxLength(5000);

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.CompletedAt);

        // Donation → Transactions
        builder.HasOne(x => x.Donation)
            .WithMany()
            .HasForeignKey(x => x.DonationId)
            .OnDelete(DeleteBehavior.Restrict);

        // Transaction ID should be unique per payment provider
        builder.HasIndex(x => new
        {
            x.PaymentProvider,
            x.TransactionId
        })
        .IsUnique();

        builder.HasIndex(x => x.DonationId);

        builder.HasIndex(x => x.Status);

        builder.HasIndex(x => x.CreatedAt);

        builder.HasIndex(x => new
        {
            x.DonationId,
            x.Status
        });
    }
}