using Donora.Shared.Abstractions.Domains;

public sealed record SubjectAddedEvent(
    long SubjectId,
    string Name,
    string Description,
    string CreatedBy
) : IDomainEvent;

public sealed record SubjectUpdatedEvent(
    long SubjectId,
    string Name,
    string Description,
    string UpdatedBy
) : IDomainEvent;

public sealed record SubjectDeletedEvent(
    long SubjectId
) : IDomainEvent;

