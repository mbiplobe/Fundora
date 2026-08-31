
using Donora.Shared.Abstractions.Commands;

internal sealed class CreateUserEntityHandler : ICommandHandler<CreateUserCommand>
{
    private readonly IUserEntityRepository _repository;

    public CreateUserEntityHandler(IUserEntityRepository repository)
        => _repository = repository;

    public async Task HandleAsync(CreateUserCommand command)
    {

        var Id = EntityID.NewId();

        var fullName = new FullName(command.FirstName, command.MiddleName, command.LastName);
        var email = new Email(command.Email);
        var mobile = new Phone(command.Mobile);
        var password = new Password(command.Password);

        var user = new UserEntity(
            Id,
            fullName,
            email,
            mobile,
            password
        );
        await _repository.AddAsync(user);
    }

}

