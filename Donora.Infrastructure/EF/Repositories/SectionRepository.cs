using Microsoft.EntityFrameworkCore;
using Donora.Infrastructure.EF.Contexts;

namespace Donora.Infrastructure.EF.Repositories;
internal sealed class SectionRepository : ISectionRepository
{
    private readonly DbSet<SectionEntity> _sectionEntities;
    private readonly WriteDbContext _writeDbContext;

    public SectionRepository(WriteDbContext writeDbContext)
    {
        _sectionEntities = writeDbContext.Sections;
        _writeDbContext = writeDbContext;
    }

    public async Task AddAsync(SectionEntity sectionEntity)
    {
       await _sectionEntities.AddAsync(sectionEntity);
       await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(SectionEntity sectionEntity)
    {
          _sectionEntities.Remove(sectionEntity);
          await _writeDbContext.SaveChangesAsync();
    }

    public async Task<SectionEntity?> GetAsync(long id)
    {
        return await _sectionEntities.SingleOrDefaultAsync(pl => pl.Id == id);
    }

   
    public async Task UpdateAsync(SectionEntity sectionEntity)
    {
         _sectionEntities.Update(sectionEntity);
        await _writeDbContext.SaveChangesAsync();
    }

}