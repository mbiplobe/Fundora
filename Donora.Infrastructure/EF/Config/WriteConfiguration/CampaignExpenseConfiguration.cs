using Donora.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donora.Infrastructure.EF.Configurations;

internal sealed class CampaignExpenseConfiguration
    : IEntityTypeConfiguration<CampaignExpense>
{
    public void Configure(EntityTypeBuilder<CampaignExpense> builder)
    {
        builder.ToTable("campaign_expenses");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.CampaignId)
            .IsRequired();

        builder.Property(x => x.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(1000);

        builder.Property(x => x.Amount)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.ExpenseDate)
            .IsRequired();

        builder.Property(x => x.ReceiptUrl)
            .HasMaxLength(1000);

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.HasOne(x => x.Campaign)
            .WithMany(x => x.Expenses)
            .HasForeignKey(x => x.CampaignId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.CampaignId);

        builder.HasIndex(x => x.ExpenseDate);

        builder.HasIndex(x => new
        {
            x.CampaignId,
            x.ExpenseDate
        });
    }
}