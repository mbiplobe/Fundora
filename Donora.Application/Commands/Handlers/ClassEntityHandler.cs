
using Donora.Shared.Abstractions.Commands;

internal sealed class ClassAddEntityHandler : ICommandHandler<CreateClassCommand>
{
    private readonly IClassRepository _repository;

    public ClassAddEntityHandler(IClassRepository repository)
        => _repository = repository;

    public async Task HandleAsync(CreateClassCommand command)
    {
        var name = new ClassName(command.Name);
        

        var classEntity = new ClassEntity(
            id: 0, 
            name,
            command.Description,
            command.CreatedBy
        );

        await _repository.AddAsync(classEntity);
    }
}

internal sealed class ClassUpdateEntityHandler : ICommandHandler<UpdateClassCommand>
{
    private readonly IClassRepository _repository;

    public ClassUpdateEntityHandler(IClassRepository repository)
        => _repository = repository;

    public async Task HandleAsync(UpdateClassCommand command)
    {
        var classEntity = await _repository.GetAsync(command.Id);

        if (classEntity is null)
        {
            throw new ClassNotFoundException(command.Id);
        }

        classEntity.UpdateProfile(command.Name, command.Description, command.UpdatedBy);

        await _repository.UpdateAsync(classEntity);
    }
}

internal sealed class ClassDeleteEntityHandler : ICommandHandler<DeleteClassCommand>
{
     private readonly IClassRepository _repository;

    public ClassDeleteEntityHandler(IClassRepository repository)
        => _repository = repository;

    public async Task HandleAsync(DeleteClassCommand command)
    {
        var classEntity = await _repository.GetAsync(command.Id);

        if (classEntity is null)
        {
            throw new ClassNotFoundException(command.Id);
        }

        await _repository.DeleteAsync(classEntity);
    }

}


