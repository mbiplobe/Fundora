namespace Donora.Infrastructure.EF.Models;

internal class OrganizationReadModel : BaseModel
{
    public string? Name { get; set; }

    public string? Slug { get; set; }

    public string? Description { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public bool IsVerified { get; set; }

    public bool IsActive { get; set; }
}