using Donora.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Donora.Infrastructure.EF.Contexts;

internal sealed class WriteDbContext : DbContext
{
    public WriteDbContext(
        DbContextOptions<WriteDbContext> options)
        : base(options)
    {
    }

    public DbSet<UserEntity> Users => Set<UserEntity>();

    public DbSet<Organization> Organizations => Set<Organization>();

    public DbSet<Campaign> Campaigns => Set<Campaign>();

    public DbSet<Beneficiary> Beneficiaries => Set<Beneficiary>();

    public DbSet<CampaignBeneficiary> CampaignBeneficiaries
        => Set<CampaignBeneficiary>();

    public DbSet<CampaignDocument> CampaignDocuments
        => Set<CampaignDocument>();

    public DbSet<CampaignExpense> CampaignExpenses
        => Set<CampaignExpense>();

    public DbSet<Donor> Donors => Set<Donor>();

    public DbSet<Donation> Donations => Set<Donation>();

    public DbSet<DonationTransaction> DonationTransactions
        => Set<DonationTransaction>();

    public DbSet<DonationReceipt> DonationReceipts
        => Set<DonationReceipt>();

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(WriteDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}