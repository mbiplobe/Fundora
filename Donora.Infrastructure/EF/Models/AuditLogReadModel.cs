namespace Donora.Infrastructure.EF.Models;

internal class AuditLogReadModel : BaseModel
{
    public Guid? UserId { get; set; }

    public string? Action { get; set; }

    public string? EntityName { get; set; }

    public Guid EntityId { get; set; }

    public string? OldValues { get; set; }

    public string? NewValues { get; set; }

    public string? IpAddress { get; set; }

    public DateTime CreatedAt { get; set; }
}