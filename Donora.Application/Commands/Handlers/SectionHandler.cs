using Donora.Shared.Abstractions.Commands;

internal sealed class SectionAddEntityHandler : ICommandHandler<CreateSectionCommand>
{
    private readonly ISectionRepository _repository;

    public SectionAddEntityHandler(ISectionRepository repository)
        => _repository = repository;

    public async Task HandleAsync(CreateSectionCommand command)
    {
        var name = new SectionName(command.Name);

        var sectionEntity = new SectionEntity(
            id: 0,
            name: name,
            description: command.Description ?? string.Empty,
            createdBy: command.CreatedBy ?? string.Empty
        );

        await _repository.AddAsync(sectionEntity);
    }
}

internal sealed class SectionUpdateEntityHandler : ICommandHandler<UpdateSectionCommand>
{
    private readonly ISectionRepository _repository;

    public SectionUpdateEntityHandler(ISectionRepository repository)
        => _repository = repository;

    public async Task HandleAsync(UpdateSectionCommand command)
    {
        var sectionEntity = await _repository.GetAsync(command.Id);

        if (sectionEntity is null)
        {
            throw new SectionNotFoundException(command.Id);
        }

        sectionEntity.UpdateSection(command.Name,command.Description, command.UpdatedBy);

        await _repository.UpdateAsync(sectionEntity);
    }
}

internal sealed class SectionDeleteEntityHandler : ICommandHandler<DeleteSectionCommand>
{
     private readonly ISectionRepository _repository;

    public SectionDeleteEntityHandler(ISectionRepository repository)
        => _repository = repository;

    public async Task HandleAsync(DeleteSectionCommand command)
    {
        var sectionEntity = await _repository.GetAsync(command.Id);

        if (sectionEntity is null)
        {
            throw new SectionNotFoundException(command.Id);
        }

        await _repository.DeleteAsync(sectionEntity);
    }

}


