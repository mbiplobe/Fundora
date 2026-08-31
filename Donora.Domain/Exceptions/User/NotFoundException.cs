using Donora.Shared.Abstractions.Exceptions;

public class NotFoundException(string message) : PublicException(message)
{
}