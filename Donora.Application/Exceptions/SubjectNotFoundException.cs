
using Donora.Shared.Abstractions.Exceptions;

public class SubjectNotFoundException : PublicException
{
    public long Id { get; }

    public SubjectNotFoundException(long id)
        : base($"Subject with ID '{id}' was not found.")
    {
        Id = id;
    }
}
