using Microsoft.EntityFrameworkCore;
using Donora.Infrastructure.EF.Models;

namespace Donora.Infrastructure.EF.Contexts;

internal sealed class ReadDbContext : DbContext
{
    public ReadDbContext(
        DbContextOptions<ReadDbContext> options)
        : base(options)
    {
    }

    public DbSet<OrganizationReadModel> Organizations => Set<OrganizationReadModel>();
    public DbSet<DonorReadModel> Donors => Set<DonorReadModel>();
    public DbSet<CampaignReadModel> Campaigns => Set<CampaignReadModel>();
    public DbSet<DonationReadModel> Donations => Set<DonationReadModel>();
    public DbSet<UserReadModel> Users => Set<UserReadModel>();
    public DbSet<DonationTransactionReadModel> DonationTransactions => Set<DonationTransactionReadModel>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ReadDbContext).Assembly,
            type => type.Name.EndsWith("ReadConfiguration"));

        base.OnModelCreating(modelBuilder);
    }
}