using Microsoft.EntityFrameworkCore;
using Donora.Infrastructure.EF.Contexts;

namespace Donora.Infrastructure.EF.Repositories;

internal sealed class SubjectRepository : ISubjectRepository
{
    private readonly DbSet<SubjectEntity> _subjectEntities;
    private readonly WriteDbContext _writeDbContext;

    public SubjectRepository(WriteDbContext writeDbContext)
    {
        _subjectEntities = writeDbContext.Subjects;
        _writeDbContext = writeDbContext;
    }

    public async Task AddAsync(SubjectEntity subjectEntity)
    {
        await _subjectEntities.AddAsync(subjectEntity);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task<SubjectEntity?> GetAsync(long id)
    {
        return await _subjectEntities
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(SubjectEntity subjectEntity)
    {
        _subjectEntities.Update(subjectEntity);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(SubjectEntity subjectEntity)
    {
        _subjectEntities.Remove(subjectEntity);
        await _writeDbContext.SaveChangesAsync();
    }
}