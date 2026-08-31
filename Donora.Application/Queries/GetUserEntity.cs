using Donora.Shared.Abstractions.Queries;

public class GetUserEntity : IQuery<UserEntityDto>
{
    public Guid Id { get; set; }
}