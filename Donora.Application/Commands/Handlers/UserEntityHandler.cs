
using Donora.Domain.Entities;
using Donora.Domain.Repositories;
using Donora.Shared.Abstractions.Commands;

internal sealed class CreateUserEntityHandler : ICommandHandler<SignUpCommand>
{
    private readonly IUserRepository _repository;

    public CreateUserEntityHandler(IUserRepository repository)
        => _repository = repository;

    public async Task HandleAsync(SignUpCommand command)
    {

        var Id = EntityID.NewId();

        // var fullName = new FullName(command.FirstName, command.MiddleName, command.LastName);
        // var email = new Email(command.Email);
        // var mobile = new Phone(command.Mobile);
        // var password = new Password(command.Password);

        var user = new UserEntity(
            Id,
            command.FirstName,
            command.LastName,
            command.Email,
            command.Mobile,
            command.Password,
            command.MiddleName
        );
        await _repository.AddAsync(user);
    }

   
}

