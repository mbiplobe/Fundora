namespace Donora.Infrastructure.EF.Models;

internal class BaseModel
{
     public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; } = null!;
    public DateTime? UpdatedDate { get; set; }
    public string? UpdatedBy { get; set; }
    // public string? Action { get; set; }
}

public enum ActionType
{
    Create,
    Update,
    Delete
}
