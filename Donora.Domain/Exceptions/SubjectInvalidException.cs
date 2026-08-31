using Donora.Shared.Abstractions.Exceptions;

public class SubjectInvalidException : PublicException
{
    public SubjectInvalidException(string message)
        : base(message)
    {
    }
}
