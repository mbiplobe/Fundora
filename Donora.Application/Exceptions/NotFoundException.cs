using Donora.Shared.Abstractions.Exceptions;

public class SectionNotFoundException : PublicException
{
    public long Id { get; }

    public SectionNotFoundException(long id) : base($"Section with ID '{id}' was not found.")
        => Id = id;
}

public class ClassNotFoundException : PublicException
{
    public long Id { get; }

    public ClassNotFoundException(long id) : base($"Class with ID '{id}' was not found.")
        => Id = id;
}