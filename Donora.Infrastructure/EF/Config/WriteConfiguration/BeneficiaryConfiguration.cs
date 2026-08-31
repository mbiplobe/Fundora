using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Donora.Domain.Entities;

namespace Donora.Infrastructure.EF.Configurations;

internal sealed class BeneficiaryConfiguration
    : IEntityTypeConfiguration<Beneficiary>
{
    public void Configure(EntityTypeBuilder<Beneficiary> builder)
    {
        builder.ToTable("beneficiaries");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.OrganizationId)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(1000);

        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(20);

        builder.Property(x => x.Address)
            .HasMaxLength(500);

        builder.Property(x => x.VerificationStatus)
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt);

        // Organization Relationship
        builder.HasOne(x => x.Organization)
            .WithMany(x => x.Beneficiaries)
            .HasForeignKey(x => x.OrganizationId)
            .OnDelete(DeleteBehavior.Restrict);

        // CampaignBeneficiaries Relationship
        builder.HasMany(x => x.CampaignBeneficiaries)
            .WithOne(x => x.Beneficiary)
            .HasForeignKey(x => x.BeneficiaryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.OrganizationId);

        builder.HasIndex(x => x.VerificationStatus);

        builder.HasIndex(x => new
        {
            x.OrganizationId,
            x.Name
        });
    }
}