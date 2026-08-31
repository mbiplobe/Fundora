using Donora.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donora.Infrastructure.EF.Configurations;

internal sealed class CampaignDocumentConfiguration
    : IEntityTypeConfiguration<CampaignDocument>
{
    public void Configure(EntityTypeBuilder<CampaignDocument> builder)
    {
        builder.ToTable("campaign_documents");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.CampaignId)
            .IsRequired();

        builder.Property(x => x.DocumentType)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.FileName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.FileUrl)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(x => x.UploadedAt)
            .IsRequired();

        builder.HasOne(x => x.Campaign)
            .WithMany(x => x.Documents)
            .HasForeignKey(x => x.CampaignId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.CampaignId);

        builder.HasIndex(x => x.DocumentType);

        builder.HasIndex(x => new
        {
            x.CampaignId,
            x.DocumentType
        });
    }
}