
using Donora.Domain.Entities;
using Donora.Domain.Repositories;
using Donora.Shared.Abstractions.Commands;

internal sealed class CreateUserEntityHandler : ICommandHandler<SignUpCommand>
{
    private readonly IUserRepository _repository;
    private readonly IUserRegistrationService _userRegistrationService;

    public CreateUserEntityHandler(IUserRepository repository, IUserRegistrationService userRegistrationService)
    {
        _repository = repository;
        _userRegistrationService = userRegistrationService;
    }

    public async Task HandleAsync(SignUpCommand command)
    {

        var Id = EntityID.NewId();

        var user = new UserEntity(
            Id,
            command.FirstName,
            command.LastName,
            command.Email,
            command.Mobile,
            command.Password,
            command.MiddleName
        );

        var validationResponse = await _userRegistrationService.ValidateAsync(
            new UserRegistrationValidationRequest(
                command.Email,
                command.Mobile,
                command.UserName));

        if (!validationResponse.IsValid)
        {
            throw new InvalidOperationException(validationResponse.Message);
        }

        await _repository.AddAsync(user);
    }


}

