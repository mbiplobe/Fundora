namespace Donora.Infrastructure.EF.Models;

internal sealed class UserReadModel : BaseModel
{
    public string FirstName { get; set; } = string.Empty;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Mobile { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;

     public string PasswordHash { get; set; } = string.Empty;
}