namespace Donora.Infrastructure.EF.Models;
internal class DashboardReadModel
{
    public int TotalOrganizations { get; set; }

    public int TotalCampaigns { get; set; }

    public int TotalDonors { get; set; }

    public int TotalDonations { get; set; }

    public decimal TotalDonationAmount { get; set; }

    public int ActiveCampaigns { get; set; }

    public int CompletedCampaigns { get; set; }
}