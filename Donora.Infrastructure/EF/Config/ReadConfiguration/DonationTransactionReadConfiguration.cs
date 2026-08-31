using Donora.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal sealed class DonationTransactionReadConfiguration
    : IEntityTypeConfiguration<DonationTransactionReadModel>
{
    public void Configure(EntityTypeBuilder<DonationTransactionReadModel> builder)
    {
        builder.ToTable("donation_transactions");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.TransactionId)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.PaymentProvider)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.PaymentMethod)
            .HasMaxLength(50);

        builder.Property(x => x.Amount)
            .HasPrecision(18, 2);

        builder.Property(x => x.Currency)
            .HasMaxLength(3);
    }
}