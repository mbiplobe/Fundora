using Donora.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donora.Infrastructure.EF.Configurations;

internal sealed class DonationReceiptConfiguration
    : IEntityTypeConfiguration<DonationReceipt>
{
    public void Configure(EntityTypeBuilder<DonationReceipt> builder)
    {
        builder.ToTable("donation_receipts");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.DonationId)
            .IsRequired();

        builder.Property(x => x.ReceiptNumber)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.ReceiptUrl)
            .HasMaxLength(1000);

        builder.Property(x => x.IssuedAt)
            .IsRequired();

        // Donation - Receipt (One-to-One)
        builder.HasOne(x => x.Donation)
            .WithOne()
            .HasForeignKey<DonationReceipt>(x => x.DonationId)
            .OnDelete(DeleteBehavior.Cascade);

        // Unique receipt number
        builder.HasIndex(x => x.ReceiptNumber)
            .IsUnique();

        // One receipt per donation
        builder.HasIndex(x => x.DonationId)
            .IsUnique();
    }
}