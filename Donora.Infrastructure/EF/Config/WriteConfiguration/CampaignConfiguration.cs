using Donora.Domain.Entities;
using Donora.Domain.Enums;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donora.Infrastructure.EF.Configurations;

internal sealed class CampaignConfiguration
    : IEntityTypeConfiguration<Campaign>
{
    public void Configure(EntityTypeBuilder<Campaign> builder)
    {
        builder.ToTable("campaigns");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.OrganizationId)
            .IsRequired();

        builder.Property(x => x.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Slug)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(5000);

        builder.Property(x => x.TargetAmount)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.CollectedAmount)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.Currency)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(x => x.Status)
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.CoverImageUrl)
            .HasMaxLength(1000);

        builder.Property(x => x.IsFeatured)
            .IsRequired();

        builder.Property(x => x.StartDate)
            .IsRequired();

        builder.Property(x => x.EndDate);

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt);

        // Organization
        builder.HasOne(x => x.Organization)
            .WithMany(x => x.Campaigns)
            .HasForeignKey(x => x.OrganizationId)
            .OnDelete(DeleteBehavior.Restrict);

        // Donations
        builder.HasMany(x => x.Donations)
            .WithOne(x => x.Campaign)
            .HasForeignKey(x => x.CampaignId)
            .OnDelete(DeleteBehavior.Restrict);

        // Expenses
        builder.HasMany(x => x.Expenses)
            .WithOne(x => x.Campaign)
            .HasForeignKey(x => x.CampaignId)
            .OnDelete(DeleteBehavior.Cascade);

        // Documents
        builder.HasMany(x => x.Documents)
            .WithOne(x => x.Campaign)
            .HasForeignKey(x => x.CampaignId)
            .OnDelete(DeleteBehavior.Cascade);

        // Beneficiaries
        builder.HasMany(x => x.CampaignBeneficiaries)
            .WithOne(x => x.Campaign)
            .HasForeignKey(x => x.CampaignId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(x => x.OrganizationId);

        builder.HasIndex(x => x.Status);

        builder.HasIndex(x => x.IsFeatured);

        builder.HasIndex(x => x.StartDate);

        builder.HasIndex(x => x.EndDate);

        builder.HasIndex(x => x.Slug)
            .IsUnique();

        builder.HasIndex(x => new
        {
            x.OrganizationId,
            x.Status
        });
    }
}