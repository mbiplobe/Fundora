using Donora.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donora.Infrastructure.EF.Configurations;

internal sealed class CampaignBeneficiaryConfiguration
    : IEntityTypeConfiguration<CampaignBeneficiary>
{
    public void Configure(EntityTypeBuilder<CampaignBeneficiary> builder)
    {
        builder.ToTable("campaign_beneficiaries");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.CampaignId)
            .IsRequired();

        builder.Property(x => x.BeneficiaryId)
            .IsRequired();

        builder.HasOne(x => x.Campaign)
            .WithMany(x => x.CampaignBeneficiaries)
            .HasForeignKey(x => x.CampaignId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Beneficiary)
            .WithMany(x => x.CampaignBeneficiaries)
            .HasForeignKey(x => x.BeneficiaryId)
            .OnDelete(DeleteBehavior.Cascade);

        // একই Beneficiary যেন একই Campaign-এ দুইবার না আসে
        builder.HasIndex(x => new
        {
            x.CampaignId,
            x.BeneficiaryId
        })
        .IsUnique();
    }
}