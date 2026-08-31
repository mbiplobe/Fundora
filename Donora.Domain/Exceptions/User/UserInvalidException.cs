using Donora.Shared.Abstractions.Exceptions;

public class UserInvalidException(string message) : PublicException(message)
{
}
