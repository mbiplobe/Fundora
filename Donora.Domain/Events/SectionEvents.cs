using Donora.Shared.Abstractions.Domains;

public sealed record SectionAddedEvent(
    long SectionId,
    string Name,
    string Description,
    string CreatedBy
) : IDomainEvent;

public sealed record SectionUpdatedEvent(
    long SectionId,
    string Name,
    string Description,
    string UpdatedBy
) : IDomainEvent;

public sealed record SectionDeletedEvent(
    long SectionId
) : IDomainEvent;
