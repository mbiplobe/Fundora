using Donora.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donora.Infrastructure.EF.Configurations;

internal sealed class OrganizationConfiguration
    : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.ToTable("organizations");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Slug)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(2000);

        builder.Property(x => x.Email)
            .HasMaxLength(255);

        builder.Property(x => x.Phone)
            .HasMaxLength(30);

        builder.Property(x => x.Address)
            .HasMaxLength(500);

        builder.Property(x => x.Website)
            .HasMaxLength(500);

        builder.Property(x => x.LogoUrl)
            .HasMaxLength(1000);

        builder.Property(x => x.OwnerUserId);

        builder.Property(x => x.IsVerified)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt);

        // Organization → Campaigns
        builder.HasMany(x => x.Campaigns)
            .WithOne(x => x.Organization)
            .HasForeignKey(x => x.OrganizationId)
            .OnDelete(DeleteBehavior.Restrict);

        // Organization → Beneficiaries
        builder.HasMany(x => x.Beneficiaries)
            .WithOne(x => x.Organization)
            .HasForeignKey(x => x.OrganizationId)
            .OnDelete(DeleteBehavior.Restrict);

        // Indexes
        builder.HasIndex(x => x.Slug)
            .IsUnique();

        builder.HasIndex(x => x.OwnerUserId);

        builder.HasIndex(x => x.IsVerified);

        builder.HasIndex(x => x.IsActive);

        builder.HasIndex(x => new
        {
            x.IsActive,
            x.IsVerified
        });
    }
}