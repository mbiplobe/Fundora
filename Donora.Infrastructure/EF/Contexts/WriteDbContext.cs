using Donora.Infrastructure.EF.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Donora.Infrastructure.EF.Contexts;

internal sealed class WriteDbContext : DbContext
{
    public DbSet<BeneficiaryConfiguration> BeneficiaryConfigurations { get; set; }
    public DbSet<CampaignBeneficiaryConfiguration> CampaignBeneficiaryConfigurations { get; set; }
    public DbSet<CampaignConfiguration> CampaignConfigurations { get; set; }
    public DbSet<CampaignDocumentConfiguration> CampaignDocumentConfigurations { get; set; }
    public DbSet<CampaignExpenseConfiguration> CampaignExpenseConfigurations { get; set; }
    public DbSet<DonationConfiguration> DonationConfigurations { get; set; }
    public DbSet<DonationReceiptConfiguration> DonationReceiptConfigurations { get; set; }
    public DbSet<DonationTransactionConfiguration> DonationTransactionConfigurations { get; set; }
    public DbSet<DonorConfiguration> DonorConfigurations { get; set; }
    public DbSet<OrganizationConfiguration> OrganizationConfigurations { get; set; }


    public WriteDbContext(DbContextOptions<WriteDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(WriteDbContext).Assembly);
    }
}