using Donora.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donora.Infrastructure.EF.Configurations;

internal sealed class DonationConfiguration
    : IEntityTypeConfiguration<Donation>
{
    public void Configure(EntityTypeBuilder<Donation> builder)
    {
        builder.ToTable("donations");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.CampaignId)
            .IsRequired();

        builder.Property(x => x.DonorId);

        builder.Property(x => x.Amount)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.Currency)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(x => x.IsAnonymous)
            .IsRequired();

        builder.Property(x => x.Message)
            .HasMaxLength(1000);

        builder.Property(x => x.Status)
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.PaymentMethod)
            .HasMaxLength(50);

        builder.Property(x => x.TransactionId)
            .HasMaxLength(150);

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        // Campaign relationship
        builder.HasOne(x => x.Campaign)
            .WithMany(x => x.Donations)
            .HasForeignKey(x => x.CampaignId)
            .OnDelete(DeleteBehavior.Restrict);

        // Donor relationship
        builder.HasOne(x => x.Donor)
            .WithMany(x => x.Donations)
            .HasForeignKey(x => x.DonorId)
            .OnDelete(DeleteBehavior.SetNull);

        // Indexes
        builder.HasIndex(x => x.CampaignId);

        builder.HasIndex(x => x.DonorId);

        builder.HasIndex(x => x.Status);

        builder.HasIndex(x => x.CreatedAt);

        builder.HasIndex(x => x.TransactionId)
            .IsUnique()
            .HasFilter("transaction_id IS NOT NULL");

        builder.HasIndex(x => new
        {
            x.CampaignId,
            x.Status,
            x.CreatedAt
        });
    }
}