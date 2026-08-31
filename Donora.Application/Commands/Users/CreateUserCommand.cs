using Donora.Shared.Abstractions.Commands;

public record CreateUserCommand(
Guid? Id,
string FirstName,
string? MiddleName,
string LastName,
string Email,
string Mobile,
string Password) : ICommand;


