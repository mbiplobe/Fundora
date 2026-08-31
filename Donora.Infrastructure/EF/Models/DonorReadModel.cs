namespace Donora.Infrastructure.EF.Models;

internal class DonorReadModel : BaseModel
{
    public string? DisplayName { get; set; }

    public bool IsAnonymous { get; set; }

    public DateTime CreatedAt { get; set; }
}