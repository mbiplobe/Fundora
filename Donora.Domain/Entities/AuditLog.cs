using Donora.Shared.Abstractions.Domains;

namespace Donora.Domain.Entities;

public sealed class AuditLog : AggregateRoot<Guid>
{

    public Guid? UserId { get; private set; }

    public string Action { get; private set; } = string.Empty;

    public string EntityName { get; private set; } = string.Empty;

    public Guid EntityId { get; private set; }

    public string? OldValues { get; private set; }

    public string? NewValues { get; private set; }

    public string? IpAddress { get; private set; }

    public DateTime CreatedAt { get; private set; }

    private AuditLog()
    {
    }

    public AuditLog(
        string action,
        string entityName,
        Guid entityId,
        Guid? userId = null)
    {
        Id = Guid.NewGuid();

        Action = action;
        EntityName = entityName;
        EntityId = entityId;
        UserId = userId;

        CreatedAt = DateTime.UtcNow;
    }
}