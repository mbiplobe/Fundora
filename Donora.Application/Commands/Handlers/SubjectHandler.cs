using Donora.Shared.Abstractions.Commands;

internal sealed class SubjectAddEntityHandler : ICommandHandler<CreateSubjectCommand>
{
    private readonly ISubjectRepository _repository;

    public SubjectAddEntityHandler(ISubjectRepository repository)
        => _repository = repository;

    public async Task HandleAsync(CreateSubjectCommand command)
    {
        var name = new SubjectName(command.Name);

        var subjectEntity = new SubjectEntity(
            id: 0,
            name: name,
            description: command.Description ?? string.Empty,
            createdBy: command.CreatedBy ?? string.Empty
        );

        await _repository.AddAsync(subjectEntity);
    }
}

internal sealed class SubjectUpdateEntityHandler : ICommandHandler<UpdateSubjectCommand>
{
    private readonly ISubjectRepository _repository;

    public SubjectUpdateEntityHandler(ISubjectRepository repository)
        => _repository = repository;

    public async Task HandleAsync(UpdateSubjectCommand command)
    {
        var subjectEntity = await _repository.GetAsync(command.Id);

        if (subjectEntity is null)
        {
            throw new SubjectNotFoundException(command.Id);
        }

        subjectEntity.UpdateSubject(
            new SubjectName(command.Name),
            command.Description ?? string.Empty,
            command.UpdatedBy
        );

        await _repository.UpdateAsync(subjectEntity);
    }
}

internal sealed class SubjectDeleteEntityHandler : ICommandHandler<DeleteSubjectCommand>
{
    private readonly ISubjectRepository _repository;

    public SubjectDeleteEntityHandler(ISubjectRepository repository)
        => _repository = repository;

    public async Task HandleAsync(DeleteSubjectCommand command)
    {
        var subjectEntity = await _repository.GetAsync(command.Id);

        if (subjectEntity is null)
        {
            throw new SubjectNotFoundException(command.Id);
        }

        await _repository.DeleteAsync(subjectEntity);
    }
}
