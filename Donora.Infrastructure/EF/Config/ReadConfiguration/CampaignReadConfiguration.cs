using Donora.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal sealed class CampaignReadConfiguration
    : IEntityTypeConfiguration<CampaignReadModel>
{
    public void Configure(EntityTypeBuilder<CampaignReadModel> builder)
    {
        builder.ToTable("campaigns");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.OrganizationName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.TargetAmount).IsRequired();

        builder.Property(x => x.Slug)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(x => x.TargetAmount)
            .HasPrecision(18, 2);

        builder.Property(x => x.CollectedAmount)
            .HasPrecision(18, 2);

        builder.Property(x => x.Currency)
            .HasMaxLength(3);

        builder.Property(x => x.Status)
            .IsRequired();

        builder.Property(x => x.StartDate);


        builder.Property(x => x.EndDate);

    }
}