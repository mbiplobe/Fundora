using Donora.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donora.Infrastructure.EF.Configurations;

internal sealed class DonorConfiguration
    : IEntityTypeConfiguration<Donor>
{
    public void Configure(EntityTypeBuilder<Donor> builder)
    {
        builder.ToTable("donors");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.UserId);

        builder.Property(x => x.DisplayName)
            .HasMaxLength(200);

        builder.Property(x => x.IsAnonymous)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt);

        // User → Donor
        builder.HasOne<UserEntity>()
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.SetNull);

        // Donor → Donations
        builder.HasMany(x => x.Donations)
            .WithOne(x => x.Donor)
            .HasForeignKey(x => x.DonorId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(x => x.UserId);

        builder.HasIndex(x => x.CreatedAt);

        builder.HasIndex(x => x.IsAnonymous);
    }
}