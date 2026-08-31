
using Donora.Shared.Abstractions.Commands;

public sealed record CreateSectionCommand(
    string Name,
    string Description,
    string? CreatedBy
) : ICommand;

public sealed record UpdateSectionCommand(
    long Id,
    string Name,
    string Description,
    string UpdatedBy
) : ICommand;

public sealed record DeleteSectionCommand(long Id) : ICommand;