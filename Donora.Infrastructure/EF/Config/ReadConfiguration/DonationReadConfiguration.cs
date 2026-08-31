using Donora.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal sealed class DonationReadConfiguration
    : IEntityTypeConfiguration<DonationReadModel>
{
    public void Configure(EntityTypeBuilder<DonationReadModel> builder)
    {
        builder.ToTable("donations");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Amount)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.Currency)
            .HasMaxLength(3)
            .IsRequired();

        builder.Property(x => x.Message)
            .HasMaxLength(500);

        builder.Property(x => x.Status)
            .IsRequired();
    }
}