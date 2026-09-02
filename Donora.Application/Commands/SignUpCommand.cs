
using Donora.Shared.Abstractions.Commands;

public record SignUpCommand(
Guid? Id,
string FirstName,
string? MiddleName,
string LastName,
string Email,
string Mobile,
string Password) : ICommand;