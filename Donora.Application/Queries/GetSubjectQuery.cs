using Donora.Shared.Abstractions.Queries;

public class GetAllSubjects : IQuery<IEnumerable<SubjectEntityDto>>
{
}

public class GetPhraseSubjects : IQuery<IEnumerable<SubjectEntityDto>>
{
    public string? SearchPhrase { get; init; }
}


