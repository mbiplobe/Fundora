using Donora.Shared.Abstractions.Commands;

public sealed record CreateSubjectCommand(
    string Name,
    string? Description,
    string? CreatedBy
) : ICommand;

public sealed record UpdateSubjectCommand(
    long Id,
    string Name,
    string? Description,
    string UpdatedBy
) : ICommand;

public sealed record DeleteSubjectCommand(
    long Id
) : ICommand;
